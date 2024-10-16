using BloodDonation.Application.Commands.Request.Donors;
using BloodDonation.Application.Queries.Request.Donors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IMediator _iMediator;

        public DonorController(IMediator iMediator)
        {
            _iMediator = iMediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDonors(CancellationToken cancellationToken)
        {
            var result = await _iMediator.Send(new FindAllDonorsRequest(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDonorById(int Id, CancellationToken cancellationToken) 
        {
            var result = await _iMediator.Send(new FindDonorByIdRequest { Id = Id }, cancellationToken);
            if (result.Succeeded)
                return Ok(result);
            return NotFound(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDonorRequest request, CancellationToken cancellationToken)
        {
            var result = await _iMediator.Send(request, cancellationToken);
            if (result.Succeeded)
                return StatusCode(201, result);
            return BadRequest(result.Message);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, UpdateDonorRequest request, CancellationToken cancellationToken)
        {
            request.Id = Id;
            var result = await _iMediator.Send(request, cancellationToken);
            if (result.Succeeded)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id, CancellationToken cancellationToken)
        {
            // request
            var result = await _iMediator.Send(new DeleteDonorRequest { Id = Id }, cancellationToken);
            if (result.Succeeded)
                return Ok(result);
            return NotFound(result.Message);
        }

    }
}
