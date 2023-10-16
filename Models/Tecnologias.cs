namespace RecruitmentPlatform.Models
{
    public class Tecnologias
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Descricao { get; set; }
        public IEnumerable<User>? Users { get; set; }

    }
}
