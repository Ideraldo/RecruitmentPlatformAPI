namespace RecruitmentPlatform.DTOs.Empresa
{
    public class EmpresaDTO
    {
        public Guid Id { get; set; }
        public string? LogoPath { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }

    }
}
