using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Context;
using RecruitmentPlatform.Models;
using RecruitmentPlatform.Repository.IRepository;

namespace RecruitmentPlatform.Repository
{
    public class VagasRepository : IVagasRepository
    {
        private readonly DataContext _db;
        public VagasRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Vagas> CreateAsync(Vagas vagas)
        {
            // Se há IDs de SkillsNecessarias associados ao usuário...
            if (vagas.SkillsNecessarias != null && vagas.SkillsNecessarias.Any())
            {
                // Busque as SkillsNecessarias do banco de dados com base nos IDs fornecidos.
                var skillsFromDb = await _db.Skills.Where(s => vagas.SkillsNecessarias.Select(uSkill => uSkill.Id).Contains(s.Id)).ToListAsync();

                // Limpe a lista de SkillsNecessarias do usuário para evitar a criação de novas entidades.
                vagas.SkillsNecessarias.Clear();

                // Associe as SkillsNecessarias existentes ao usuário.
                foreach (var skill in skillsFromDb)
                {
                    vagas.SkillsNecessarias.Add(skill);
                }
            }

            // Se há IDs de Tecnologias associados ao usuário...
            if (vagas.Tecnologias != null && vagas.Tecnologias.Any())
            {
                // Busque as SkillsNecessarias do banco de dados com base nos IDs fornecidos.
                var tecnologiasFromDb = await _db.Tecnologias.Where(s => vagas.Tecnologias.Select(uTecnologia => uTecnologia.Id).Contains(s.Id)).ToListAsync();

                // Limpe a lista de SkillsNecessarias do usuário para evitar a criação de novas entidades.
                vagas.Tecnologias.Clear();

                // Associe as SkillsNecessarias existentes ao usuário.
                foreach (var tecnologia in tecnologiasFromDb)
                {
                    vagas.Tecnologias.Add(tecnologia);
                }
            }
            _db.Add(vagas);
            await _db.SaveChangesAsync();
            return vagas;
        }

        public async Task DeleteAsync(Vagas vagas)
        {
            _db.Remove(vagas);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Vagas vagas)
        {
            var dbVaga = await _db.Vagas.Include(v => v.SkillsNecessarias).Include(v => v.Tecnologias).FirstOrDefaultAsync(v => v.Id == vagas.Id);

            if (dbVaga != null)
            {
                dbVaga.EmpresaId = vagas.EmpresaId;
                // Copie outras propriedades de 'vagas' para 'dbVaga' conforme necessário.

                if (vagas.SkillsNecessarias != null && vagas.SkillsNecessarias.Any())
                {
                    var skillsFromDb = await _db.Skills.Where(s => vagas.SkillsNecessarias.Select(uSkill => uSkill.Id).Contains(s.Id)).ToListAsync();
                    dbVaga.SkillsNecessarias.Clear();

                    foreach (var skill in skillsFromDb)
                    {
                        dbVaga.SkillsNecessarias.Add(skill);
                    }
                }

                if (vagas.Tecnologias != null && vagas.Tecnologias.Any())
                {
                    var tecnologiasFromDb = await _db.Tecnologias.Where(s => vagas.Tecnologias.Select(uTecnologia => uTecnologia.Id).Contains(s.Id)).ToListAsync();
                    dbVaga.Tecnologias.Clear();

                    foreach (var tecnologia in tecnologiasFromDb)
                    {
                        dbVaga.Tecnologias.Add(tecnologia);
                    }
                }

                await _db.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<Vagas>> GetAsync()
        {
            return await _db.Vagas.Include(u => u.SkillsNecessarias)
             .Include(u => u.Tecnologias).ToListAsync();
        }

        public async Task<Vagas> GetByIdAsync(Guid id)
        {
            return await _db.Vagas.Include(u => u.SkillsNecessarias)
             .Include(u => u.Tecnologias)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

    }
}
