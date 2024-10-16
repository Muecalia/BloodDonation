using BloodDonation.Application.Queries.Response.Donors;
using BloodDonation.Application.Wrappers;
using MediatR;

namespace BloodDonation.Application.Queries.Request.Donors
{
    public class FindAllDonorsRequest : IRequest<PagedResponse<FindAllDonorsResponse>>
    {
    }
}
