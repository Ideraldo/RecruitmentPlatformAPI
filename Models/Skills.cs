namespace RecruitmentPlatform.Models
{
    public class Skills
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; } 
        public string? Descricao { get; set; }
        public IEnumerable<User>? Users { get; set; }

    }
}
