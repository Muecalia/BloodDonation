using BloodDonation.Application.Commands.Response.Donors;
using BloodDonation.Application.Wrappers;
using MediatR;

namespace BloodDonation.Application.Commands.Request.Donors
{
    public class DeleteDonorRequest : IRequest<ApiResponse<InputDonorResponse>>
    {
        public int Id { get; set; } = 0;
    }
}
