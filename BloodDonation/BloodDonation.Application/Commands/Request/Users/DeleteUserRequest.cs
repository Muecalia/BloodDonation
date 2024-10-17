using BloodDonation.Application.Commands.Response.Users;
using BloodDonation.Application.Wrappers;
using MediatR;

namespace BloodDonation.Application.Commands.Request.Users
{
    public class DeleteUserRequest : IRequest<ApiResponse<InputUserResponse>>
    {
        public DeleteUserRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; } = 0;
    }
}
