namespace RecruitmentPlatform.Models
{
    public class Empresa
    {
        public Guid Id { get; set; }
        public string? LogoPath { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
    }
}
