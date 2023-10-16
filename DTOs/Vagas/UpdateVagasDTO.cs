namespace RecruitmentPlatform.DTOs.Vagas
{
    public class UpdateVagasDTO
    {
        public Guid Id { get; set; }
        public Guid? EmpresaId { get; set; }
        public IEnumerable<Guid>? SkillsNecessarias { get; set; }
        public IEnumerable<Guid>? Tecnologias { get; set; }


    }
}
