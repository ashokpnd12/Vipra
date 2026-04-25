using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vipra.Application.DTOs.Panditji;
using Vipra.Application.Services.Panditji;

namespace Vipra.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PanditjiController : ControllerBase
    {
        private readonly IPanditService _service;

        public PanditjiController(IPanditService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePanditjiDto dto)
        {
            var result = await _service.Create(dto);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdatePanditjiDto dto)
        {
            await _service.Update(id, dto);
            return Ok("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return Ok("Deleted Successfully");
        }
    }
}
