using RecruitmentPlatform.DTOs.Empresa;
using RecruitmentPlatform.DTOs.Skills;
using RecruitmentPlatform.DTOs.Tecnologias;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentPlatform.DTOs.Vagas
{
    public class CreateVagasDTO
    {
        public Guid? EmpresaId { get; set; }
        public IEnumerable<Guid>? SkillsNecessarias { get; set; }
        public IEnumerable<Guid>? Tecnologias { get; set; }

    }
}
