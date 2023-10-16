using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Context;
using RecruitmentPlatform.Models;
using RecruitmentPlatform.Repository.IRepository;

namespace RecruitmentPlatform.Repository
{
    public class TecnologiasRepository : ITecnologiasRepository
    {
        private readonly DataContext _db;
        public TecnologiasRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Tecnologias> CreateAsync(Tecnologias tecnologias)
        {
            _db.Add(tecnologias);
            await _db.SaveChangesAsync();
            return tecnologias;
        }

        public async Task DeleteAsync(Tecnologias tecnologias)
        {
            _db.Remove(tecnologias);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Tecnologias tecnologias)
        {
            _db.Update(tecnologias);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tecnologias>> GetAsync()
        {
            return await _db.Tecnologias.ToListAsync();
        }

        public async Task<Tecnologias> GetByIdAsync(Guid id)
        {
            return await _db.Tecnologias.FirstOrDefaultAsync(u => u.Id == id);
        }

    }
}
