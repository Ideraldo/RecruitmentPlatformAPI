using RecruitmentPlatform.DTOs.Empresa;
using RecruitmentPlatform.DTOs.Skills;
using RecruitmentPlatform.DTOs.Tecnologias;
using RecruitmentPlatform.DTOs.User;

namespace RecruitmentPlatform.DTOs.Vagas
{
    public class VagasDTO
    {
        public Guid Id { get; set; }
        public virtual EmpresaDTO? Empresa { get; set; }
        public Guid? EmpresaId { get; set; }
        public IEnumerable<SkillsDTO>? SkillsNecessarias { get; set; }
        public IEnumerable<TecnologiasDTO>? Tecnologias { get; set; }
        public IEnumerable<UserDTO>? Users { get; set; }
    }
}
