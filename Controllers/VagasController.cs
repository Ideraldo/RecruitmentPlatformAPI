using Microsoft.AspNetCore.Mvc;
using RecruitmentPlatform.DTOs.Vagas;
using RecruitmentPlatform.Services.IService;

namespace RecruitmentPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VagasController : ControllerBase
    {
        private readonly IVagasService _vagasService;
        public VagasController(IVagasService vagasService)
        {
            _vagasService = vagasService;
        }

        [HttpPost("new")]
        public async Task<ActionResult> PostVagasAsync([FromForm] CreateVagasDTO vagasDTO)
        {
            var result = await _vagasService.CreateAsync(vagasDTO);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            var result = await _vagasService.GetByIdAsync(id);
            if (result == null)
                return NotFound(result);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _vagasService.GetAsync();
            if (result == null)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateVagasDTO vagasDTO)
        {
            var result = await _vagasService.UpdateAsync(vagasDTO);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
