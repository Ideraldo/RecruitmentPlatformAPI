using Microsoft.AspNetCore.Mvc;
using RecruitmentPlatform.DTOs.Empresa;
using RecruitmentPlatform.Services.IService;

namespace RecruitmentPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;
        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpPost("new")]
        public async Task<ActionResult> PostEmpresaAsync([FromForm] CreateEmpresaDTO empresaDTO)
        {
            var result = await _empresaService.CreateAsync(empresaDTO);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            var result = await _empresaService.GetByIdAsync(id);
            if (result == null)
                return NotFound(result);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _empresaService.GetAsync();
            if (result == null)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateEmpresaDTO empresaDTO)
        {
            var result = await _empresaService.UpdateAsync(empresaDTO);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
