using BloodDonation.Application.Queries.Request.Users;
using BloodDonation.Application.Queries.Response.Users;
using BloodDonation.Application.Utils;
using BloodDonation.Application.Wrappers;
using BloodDonation.Core.Repositories;
using MediatR;

namespace BloodDonation.Application.Handlers.Users
{
    public class FindAllUsersHandler : IRequestHandler<FindAllUsersRequest, PagedResponse<FindAllUsersResponse>>
    {
        private readonly IUserRepository _userRepository;

        public FindAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PagedResponse<FindAllUsersResponse>> Handle(FindAllUsersRequest request, CancellationToken cancellationToken)
        {
            const string Entidade = "utilizador";
            try
            {
                var results = new List<FindAllUsersResponse>();
                var users = await _userRepository.GetAll(cancellationToken);
                users.ForEach(u => results.Add(new FindAllUsersResponse(u.Id, u.Name, u.Email, u.Phone, u.Role)));

                return new PagedResponse<FindAllUsersResponse>(results, MensagemError.CarregamentoSucesso(Entidade, users.Count));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(MensagemError.CarregamentoErro(Entidade, ex.Message));
                throw;
            }
        }

    }
}
