using BloodDonation.Application.Commands.Request.Users;
using BloodDonation.Application.Commands.Response.Users;
using BloodDonation.Application.Utils;
using BloodDonation.Application.Wrappers;
using BloodDonation.Core.Entities;
using BloodDonation.Core.Repositories;
using BloodDonation.Core.Services;
using MediatR;

namespace BloodDonation.Application.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, ApiResponse<InputUserResponse>>
    {
        private readonly IAuthService _iAuthService;
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IAuthService iAuthService, IUserRepository userRepository)
        {
            _iAuthService = iAuthService;
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<InputUserResponse>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            const string Entidade = "utilizador";
            const string Operacao = "criar";
            try
            {
                if (await _userRepository.IsEmailExist(request.Email, cancellationToken))
                    return ApiResponse<InputUserResponse>.Error(MensagemError.ConflitoEmail(request.Email));

                if (await _userRepository.IsUserExist(request.Name, cancellationToken))
                    return ApiResponse<InputUserResponse>.Error(MensagemError.Conflito(Entidade));

                var newUser = new User
                {
                    Email = request.Email,
                    Name = request.Name,
                    Password = _iAuthService.ComputeSha256Hash(request.Password),
                    Phone = request.Phone,
                    Role = request.Role
                };

                var user = await _userRepository.Create(newUser, cancellationToken);

                var result = new InputUserResponse(user.Id, user.Name, user.Email);

                return ApiResponse<InputUserResponse>.Success(result, MensagemError.OperacaoSucesso(Entidade, Operacao));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(MensagemError.OperacaoErro(Entidade, Operacao, ex.Message));
                throw;
            }
        }
    }
}
