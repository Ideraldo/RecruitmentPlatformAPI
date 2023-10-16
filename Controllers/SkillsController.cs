using Microsoft.AspNetCore.Mvc;
using RecruitmentPlatform.DTOs.Skills;
using RecruitmentPlatform.Services.IService;

namespace RecruitmentPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsService _skillsService;
        public SkillsController(ISkillsService skillsService)
        {
            _skillsService = skillsService;
        }

        [HttpPost("new")]
        public async Task<ActionResult> PostSkillsAsync([FromForm] CreateSkillsDTO skillsDTO)
        {
            var result = await _skillsService.CreateAsync(skillsDTO);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            var result = await _skillsService.GetByIdAsync(id);
            if (result == null)
                return NotFound(result);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _skillsService.GetAsync();
            if (result == null)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateSkillsDTO skillsDTO)
        {
            var result = await _skillsService.UpdateAsync(skillsDTO);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
