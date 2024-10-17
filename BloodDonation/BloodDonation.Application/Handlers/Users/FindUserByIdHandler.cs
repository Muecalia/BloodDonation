using BloodDonation.Application.Queries.Request.Users;
using BloodDonation.Application.Queries.Response.Users;
using BloodDonation.Application.Utils;
using BloodDonation.Application.Wrappers;
using BloodDonation.Core.Repositories;
using MediatR;

namespace BloodDonation.Application.Handlers.Users
{
    public class FindUserByIdHandler : IRequestHandler<FindUserByIdRequest, ApiResponse<FindUserByIdResponse>>
    {
        private readonly IUserRepository _userRepository;

        public FindUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<FindUserByIdResponse>> Handle(FindUserByIdRequest request, CancellationToken cancellationToken)
        {
            const string Entidade = "utilizador";
            try
            {
                var user = await _userRepository.GetByIdDetail(request.Id, cancellationToken);
                if (user == null)
                    return ApiResponse<FindUserByIdResponse>.Error(MensagemError.NotFound(Entidade));

                var result = new FindUserByIdResponse(user.Id, user.Name, user.Email, user.Phone, user.Role, user.CreatedAt.ToShortTimeString());
                return ApiResponse<FindUserByIdResponse>.Success(result, MensagemError.CarregamentoSucesso(Entidade));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(MensagemError.CarregamentoErro(Entidade, ex.Message));
                throw;
            }
        }
    }
}
