using BloodDonation.Application.Queries.Response.Users;
using BloodDonation.Application.Wrappers;
using MediatR;

namespace BloodDonation.Application.Queries.Request.Users
{
    public class FindUserByIdRequest : IRequest<ApiResponse<FindUserByIdResponse>>
    {
        public FindUserByIdRequest(int id) 
        { 
            Id = id;
        }

        public int Id { get; set; } = 0;
    }
}
