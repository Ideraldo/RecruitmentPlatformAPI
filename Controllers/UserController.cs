using Microsoft.AspNetCore.Mvc;
using RecruitmentPlatform.DTOs.User;
using RecruitmentPlatform.Services.IService;

namespace RecruitmentPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("new")]
        public async Task<ActionResult> PostUserAsync([FromForm] CreateUserDTO userDTO)
        {
            var result = await _userService.CreateAsync(userDTO);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result == null)
                return NotFound(result);
            return Ok(result);
        }  
        
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _userService.GetAsync();
            if (result == null)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateUserDTO userDTO)
        {
            var result = await _userService.UpdateAsync(userDTO);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        } 
        [HttpPost("curriculo")]
        public async Task<ActionResult> AdicionarCurriculo([FromForm] AddCurriculoDTO curriculoDTO)
        {
            var result = await _userService.AddCurriculoAsync(curriculoDTO);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
