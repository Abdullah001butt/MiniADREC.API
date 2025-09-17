using Microsoft.AspNetCore.Mvc;
using MiniADREC.DTO.PermitRequest;
using MiniADREC.Services.Interfaces;

namespace MiniADREC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermitRequestController : ControllerBase
    {
        private readonly IPermitRequestService _service;

        public PermitRequestController(IPermitRequestService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePermitRequestDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok("Permit request submitted");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requests = await _service.GetAllAsync();
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var request = await _service.GetByIdAsync(id);
            return request == null ? NotFound() : Ok(request);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(long userId)
        {
            var requests = await _service.GetByUserIdAsync(userId);
            return Ok(requests);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(long id, [FromQuery] string status)
        {
            await _service.UpdateStatusAsync(id, status);
            return Ok("Status updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return Ok("Permit request deleted");
        }
    }
}
