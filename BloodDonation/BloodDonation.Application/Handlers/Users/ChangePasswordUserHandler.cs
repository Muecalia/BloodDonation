using BloodDonation.Application.Commands.Request.Users;
using BloodDonation.Application.Commands.Response.Users;
using BloodDonation.Application.Utils;
using BloodDonation.Application.Wrappers;
using BloodDonation.Core.Repositories;
using BloodDonation.Core.Services;
using MediatR;

namespace BloodDonation.Application.Handlers.Users
{
    public class ChangePasswordUserHandler : IRequestHandler<ChangePasswordUserRequest, ApiResponse<InputUserResponse>>
    {
        private readonly IAuthService _iAuthService;
        private readonly IUserRepository _userRepository;

        public ChangePasswordUserHandler(IAuthService iAuthService, IUserRepository userRepository)
        {
            _iAuthService = iAuthService;
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<InputUserResponse>> Handle(ChangePasswordUserRequest request, CancellationToken cancellationToken)
        {
            const string Entidade = "utilizador";
            const string Operacao = "alterar a senha";
            try
            {
                var user = await _userRepository.GetByIdEmail(request.Id, request.Email, cancellationToken);
                if (user == null)
                    return ApiResponse<InputUserResponse>.Error(MensagemError.NotFound(Entidade));

                user.Password = _iAuthService.ComputeSha256Hash(request.NewPassword);

                await _userRepository.Update(user, cancellationToken);

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
