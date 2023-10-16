using RecruitmentPlatform.DTOs.Skills;

namespace RecruitmentPlatform.Services.IService
{
    public interface ISkillsService
    {
        Task<SkillsDTO> CreateAsync(CreateSkillsDTO userDTO);
        Task<List<SkillsDTO>> GetAsync();
        Task<SkillsDTO> GetByIdAsync(Guid id);
        Task<SkillsDTO> UpdateAsync(UpdateSkillsDTO useDTO);
    }
}
