using RecruitmentPlatform.Models;

namespace RecruitmentPlatform.Repository.IRepository
{
    public interface ISkillsRepository
    {
        Task<Skills> GetByIdAsync(Guid id);
        Task<Skills> CreateAsync(Skills user);
        Task EditAsync(Skills user);
        Task DeleteAsync(Skills user);
        Task<IEnumerable<Skills>> GetAsync();
    }
}
