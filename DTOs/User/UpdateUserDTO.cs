namespace RecruitmentPlatform.DTOs.User
{
    public class UpdateUserDTO
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public Guid? EmpresaId { get; set; }
        public IEnumerable<Guid>? Skills { get; set; }
        public IEnumerable<Guid>? Tecnologias { get; set; }
        public IEnumerable<Guid>? Vagas { get; set; }

    }
}
