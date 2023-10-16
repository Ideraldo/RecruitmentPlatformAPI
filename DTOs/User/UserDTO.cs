using RecruitmentPlatform.DTOs.Empresa;
using RecruitmentPlatform.DTOs.Skills;
using RecruitmentPlatform.DTOs.Tecnologias;
using RecruitmentPlatform.DTOs.Vagas;

namespace RecruitmentPlatform.DTOs.User
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public string? PathCurriculo { get; set; }
        public bool? IsRecruiter { get; set; }
        public bool? IsActive { get; set; }
        public EmpresaDTO? Empresa { get; set; }
        public Guid? EmpresaId { get; set; }
        public IEnumerable<Guid>? Skills { get; set; }
        public IEnumerable<Guid>? Tecnologias { get; set; }
        public IEnumerable<Guid>? Vagas { get; set; }
    }
}
