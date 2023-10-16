namespace RecruitmentPlatform.DTOs.User
{
    public class CreateUserDTO
    {
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public bool? IsRecruiter { get; set; }
        public bool? IsActive { get; set; }
        public Guid? EmpresaId { get; set; }
        public IEnumerable<Guid>? Skills { get; set; }
        public IEnumerable<Guid>? Tecnologias { get; set; }
    }
}
