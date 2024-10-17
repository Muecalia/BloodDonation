using BloodDonation.Application.Queries.Response.Users;
using BloodDonation.Application.Wrappers;
using MediatR;

namespace BloodDonation.Application.Queries.Request.Users
{
    public class FindAllUsersRequest : IRequest<PagedResponse<FindAllUsersResponse>>
    {
    }
}
