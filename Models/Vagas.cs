using System.ComponentModel.DataAnnotations;

namespace RecruitmentPlatform.Models
{
    public class Vagas
    {
        public Guid Id { get; set; }
        [Required]
        public virtual Empresa? Empresa { get; set; }
        public Guid? EmpresaId { get; set; }
        public virtual ICollection<Skills>? SkillsNecessarias { get; set; }
        public virtual ICollection<Tecnologias>? Tecnologias { get; set; }
        public virtual ICollection<User>? Users { get; set; }

    }
}
