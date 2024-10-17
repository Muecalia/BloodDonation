using BloodDonation.Application.Commands.Response.Users;
using BloodDonation.Application.Wrappers;
using MediatR;

namespace BloodDonation.Application.Commands.Request.Users
{
    public class ChangePasswordUserRequest : IRequest<ApiResponse<InputUserResponse>>
    {
        public int Id { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
