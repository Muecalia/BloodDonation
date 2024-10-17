using BloodDonation.Application.Commands.Request.Users;
using BloodDonation.Application.Commands.Response.Users;
using BloodDonation.Application.Utils;
using BloodDonation.Application.Wrappers;
using BloodDonation.Core.Repositories;
using MediatR;

namespace BloodDonation.Application.Handlers.Users
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, ApiResponse<InputUserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<InputUserResponse>> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            const string Entidade = "utilizador";
            const string Operacao = "eliminar";
            try
            {
                var user = await _userRepository.GetById(request.Id, cancellationToken);
                if (user == null)
                    return ApiResponse<InputUserResponse>.Error(MensagemError.NotFound(Entidade));

                await _userRepository.Delete(user, cancellationToken);

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
