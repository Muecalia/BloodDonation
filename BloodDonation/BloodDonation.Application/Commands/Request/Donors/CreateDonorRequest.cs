using BloodDonation.Application.Commands.Response.Donors;
using BloodDonation.Application.Wrappers;
using MediatR;

namespace BloodDonation.Application.Commands.Request.Donors
{
    public class CreateDonorRequest : IRequest<ApiResponse<InputDonorResponse>>
    {
        public string Name { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public char Gender { get; set; } = 'F';
        public string FactorRh { get; set; } = string.Empty;
        public string BloodType { get; set; } = string.Empty;
        public double Weight { get; set; } = 2f;
        public string Cep { get; set; } = string.Empty;
        public int IdUser { get; set; } = 0;
    }
}
