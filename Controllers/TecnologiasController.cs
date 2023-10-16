using Microsoft.AspNetCore.Mvc;
using RecruitmentPlatform.DTOs.Tecnologias;
using RecruitmentPlatform.Services.IService;

namespace RecruitmentPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnologiasController : ControllerBase
    {
        private readonly ITecnologiasService _tecnologiasService;
        public TecnologiasController(ITecnologiasService tecnologiasService)
        {
            _tecnologiasService = tecnologiasService;
        }

        [HttpPost("new")]
        public async Task<ActionResult> PostTecnologiasAsync([FromForm] CreateTecnologiasDTO tecnologiasDTO)
        {
            var result = await _tecnologiasService.CreateAsync(tecnologiasDTO);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            var result = await _tecnologiasService.GetByIdAsync(id);
            if (result == null)
                return NotFound(result);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _tecnologiasService.GetAsync();
            if (result == null)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateTecnologiasDTO tecnologiasDTO)
        {
            var result = await _tecnologiasService.UpdateAsync(tecnologiasDTO);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
