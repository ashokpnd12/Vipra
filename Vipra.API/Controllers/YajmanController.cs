using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vipra.Application.DTOs.Yajman;
using Vipra.Application.Services.Yajman;

namespace Vipra.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class YajmanController : ControllerBase
    {
        private readonly IYajmanService _service;

        public YajmanController(IYajmanService service)
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
        public async Task<IActionResult> Create(CreateYajmanDto dto)
        {
            var result = await _service.Create(dto);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateYajmanDto dto)
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

