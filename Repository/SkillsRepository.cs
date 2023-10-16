using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Context;
using RecruitmentPlatform.Models;
using RecruitmentPlatform.Repository.IRepository;

namespace RecruitmentPlatform.Repository
{
    public class SkillsRepository : ISkillsRepository
    {
        private readonly DataContext _db;
        public SkillsRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Skills> CreateAsync(Skills skills)
        {
            _db.Add(skills);
            await _db.SaveChangesAsync();
            return skills;
        }

        public async Task DeleteAsync(Skills skills)
        {
            _db.Remove(skills);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Skills skills)
        {
            _db.Update(skills);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Skills>> GetAsync()
        {
            return await _db.Skills.ToListAsync();
        }

        public async Task<Skills> GetByIdAsync(Guid id)
        {
            return await _db.Skills.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
