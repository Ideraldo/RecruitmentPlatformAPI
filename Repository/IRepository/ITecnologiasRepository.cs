using RecruitmentPlatform.Models;

namespace RecruitmentPlatform.Repository.IRepository
{
    public interface ITecnologiasRepository
    {
        Task<Tecnologias> GetByIdAsync(Guid id);
        Task<Tecnologias> CreateAsync(Tecnologias tecnologias);
        Task EditAsync(Tecnologias tecnologias);
        Task DeleteAsync(Tecnologias tecnologias);
        Task<IEnumerable<Tecnologias>> GetAsync();
    }
}
