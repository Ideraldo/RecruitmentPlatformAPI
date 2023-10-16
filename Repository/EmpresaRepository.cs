using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Context;
using RecruitmentPlatform.Models;
using RecruitmentPlatform.Repository.IRepository;

namespace RecruitmentPlatform.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly DataContext _db;
        public EmpresaRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Empresa> CreateAsync(Empresa empresa)
        {
            _db.Add(empresa);
            await _db.SaveChangesAsync();
            return empresa;
        }

        public async Task DeleteAsync(Empresa empresa)
        {
            _db.Remove(empresa);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Empresa empresa)
        {
            _db.Update(empresa);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Empresa>> GetAsync()
        {
            return await _db.Empresas.ToListAsync();
        }

        public async Task<Empresa> GetByIdAsync(Guid id)
        {
            return await _db.Empresas.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}

