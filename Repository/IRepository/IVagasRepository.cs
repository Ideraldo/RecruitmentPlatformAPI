using RecruitmentPlatform.Models;

namespace RecruitmentPlatform.Repository.IRepository
{
    public interface IVagasRepository
    {
        Task<Vagas> GetByIdAsync(Guid id);
        Task<Vagas> CreateAsync(Vagas vagas);
        Task EditAsync(Vagas vagas);
        Task DeleteAsync(Vagas vagas);
        Task<IEnumerable<Vagas>> GetAsync();
    }
}
