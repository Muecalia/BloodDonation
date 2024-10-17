using BloodDonation.Application.Commands.Request.Users;
using BloodDonation.Application.Queries.Request.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new FindAllUsersRequest(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new FindUserByIdRequest(Id), cancellationToken);
            if (result.Succeeded) 
                return Ok(result);
            return NotFound(result.Message);
        }

        [HttpPut("{Id}/change-password")]
        public async Task<IActionResult> ChangePassword(int Id, ChangePasswordUserRequest request, CancellationToken cancellationToken)
        {
            request.Id = Id;
            var result = await _mediator.Send(request, cancellationToken);
            if (result.Succeeded) 
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);
            if (result.Succeeded)
                return StatusCode(201, result);
            return BadRequest(result.Message);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id, CancellationToken cancellationToken) 
        {
            var result = await _mediator.Send(new DeleteUserRequest(Id), cancellationToken);
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, UpdateUserRequest request, CancellationToken cancellationToken)
        {
            request.Id = Id;
            var result = await _mediator.Send(request, cancellationToken);
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(result.Message);
        }

    }
}
