using BloodDonation.Application.Queries.Response.Donors;
using BloodDonation.Application.Wrappers;
using MediatR;

namespace BloodDonation.Application.Queries.Request.Donors
{
    public class FindDonorByIdRequest : IRequest<ApiResponse<FindDonorByIdResponse>>
    {
        public int Id { get; set; } = 0;
    }
}
