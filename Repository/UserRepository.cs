using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Context;
using RecruitmentPlatform.Models;
using RecruitmentPlatform.Repository.IRepository;

namespace RecruitmentPlatform.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _db;
        public UserRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<User> CreateAsync(User user)
        {
            // Se há IDs de Skills associados ao usuário...
            if (user.Skills != null && user.Skills.Any())
            {
                // Busque as Skills do banco de dados com base nos IDs fornecidos.
                var skillsFromDb = await _db.Skills.Where(s => user.Skills.Select(uSkill => uSkill.Id).Contains(s.Id)).ToListAsync();

                // Limpe a lista de Skills do usuário para evitar a criação de novas entidades.
                user.Skills.Clear();

                // Associe as Skills existentes ao usuário.
                foreach (var skill in skillsFromDb)
                {
                    user.Skills.Add(skill);
                }
            }

            // Se há IDs de Tecnologias associados ao usuário...
            if (user.Tecnologias != null && user.Tecnologias.Any())
            {
                // Busque as Skills do banco de dados com base nos IDs fornecidos.
                var tecnologiasFromDb = await _db.Tecnologias.Where(s => user.Tecnologias.Select(uTecnologia => uTecnologia.Id).Contains(s.Id)).ToListAsync();

                // Limpe a lista de Skills do usuário para evitar a criação de novas entidades.
                user.Tecnologias.Clear();

                // Associe as Skills existentes ao usuário.
                foreach (var tecnologia in tecnologiasFromDb)
                {
                    user.Tecnologias.Add(tecnologia);
                }
            }

            _db.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(User user)
        {
            _db.Remove(user);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(User user)
        {
            // Se há IDs de Skills associados ao usuário...
            if (user.Skills != null && user.Skills.Any())
            {
                // Busque as Skills do banco de dados com base nos IDs fornecidos.
                var skillsFromDb = await _db.Skills.Where(s => user.Skills.Select(uSkill => uSkill.Id).Contains(s.Id)).ToListAsync();

                // Limpe a lista de Skills do usuário para evitar a criação de novas entidades.
                user.Skills.Clear();

                // Associe as Skills existentes ao usuário.
                foreach (var skill in skillsFromDb)
                {
                    user.Skills.Add(skill);
                }
            }

            // Se há IDs de Tecnologias associados ao usuário...
            if (user.Tecnologias != null && user.Tecnologias.Any())
            {
                // Busque as Skills do banco de dados com base nos IDs fornecidos.
                var tecnologiasFromDb = await _db.Tecnologias.Where(s => user.Tecnologias.Select(uTecnologia => uTecnologia.Id).Contains(s.Id)).ToListAsync();

                // Limpe a lista de Skills do usuário para evitar a criação de novas entidades.
                user.Tecnologias.Clear();

                // Associe as Skills existentes ao usuário.
                foreach (var tecnologia in tecnologiasFromDb)
                {
                    user.Tecnologias.Add(tecnologia);
                }
            }


            // Se há IDs de Tecnologias associados ao usuário...
            if (user.Vagas != null && user.Vagas.Any())
            {
                // Busque as Skills do banco de dados com base nos IDs fornecidos.
                var vagasFromDb = await _db.Vagas.Where(s => user.Vagas.Select(uVagas => uVagas.Id).Contains(s.Id)).ToListAsync();

                // Limpe a lista de Skills do usuário para evitar a criação de novas entidades.
                user.Vagas.Clear();

                // Associe as Skills existentes ao usuário.
                foreach (var vaga in vagasFromDb)
                {
                    user.Vagas.Add(vaga);
                }
            }
            _db.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
           return await _db.Users
              .Include(u => u.Skills)
             .Include(u => u.Tecnologias)
             .Include(u => u.Vagas).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await _db.Users.Include(u => u.Skills)
             .Include(u => u.Tecnologias)
             .Include(u => u.Vagas).ToListAsync();
        }
    }
}
