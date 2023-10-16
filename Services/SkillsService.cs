using AutoMapper;
using RecruitmentPlatform.DTOs.Skills;
using RecruitmentPlatform.Models;
using RecruitmentPlatform.Repository.IRepository;
using RecruitmentPlatform.Services.IService;

namespace RecruitmentPlatform.Services
{
    public class SkillsService : ISkillsService
    {
        private readonly ISkillsRepository _skillsRepository;
        private readonly IMapper _mapper;

        public SkillsService(ISkillsRepository skillsRepository, IMapper mapper)
        {
            _skillsRepository = skillsRepository;
            _mapper = mapper;
        }

        public async Task<SkillsDTO> CreateAsync(CreateSkillsDTO skillsDTO)
        {
            var skills = _mapper.Map<Skills>(skillsDTO);
            var createdSkills = await _skillsRepository.CreateAsync(skills);
            return _mapper.Map<SkillsDTO>(createdSkills);
        }

        public async Task<List<SkillsDTO>> GetAsync()
        {
            var skillsList = await _skillsRepository.GetAsync();
            return _mapper.Map<List<SkillsDTO>>(skillsList);
        }

        public async Task<SkillsDTO> GetByIdAsync(Guid id)
        {
            var skills = await _skillsRepository.GetByIdAsync(id);
            return _mapper.Map<SkillsDTO>(skills);
        }

        public async Task<SkillsDTO> UpdateAsync(UpdateSkillsDTO skillsDTO)
        {
            var skills = _mapper.Map<Skills>(skillsDTO);
            await _skillsRepository.EditAsync(skills);
            return _mapper.Map<SkillsDTO>(skills);
        }
    }
}
