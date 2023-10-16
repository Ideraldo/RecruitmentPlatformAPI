namespace RecruitmentPlatform.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public string? PathCurriculo { get; set; }
        public bool? IsRecruiter { get; set; }
        public bool? IsActive { get; set; }
        public Empresa? Empresa { get; set; }
        public Guid? EmpresaId { get; set; }
        public virtual ICollection<Skills>? Skills {get;set;}
        public virtual ICollection<Tecnologias>? Tecnologias { get; set; }
        public virtual ICollection<Vagas>? Vagas { get; set; }
    }
}
