using RecruitmentPlatform.Models;

namespace RecruitmentPlatform.Repository.IRepository
{
    public interface IEmpresaRepository
    {
        Task<Empresa> GetByIdAsync(Guid id);
        Task<Empresa> CreateAsync(Empresa empresa);
        Task EditAsync(Empresa empresa);
        Task DeleteAsync(Empresa empresa);
        Task<IEnumerable<Empresa>> GetAsync();
    }
}
