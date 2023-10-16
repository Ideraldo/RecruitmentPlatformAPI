namespace RecruitmentPlatform.DTOs.User
{
    public class AddCurriculoDTO
    {
        public Guid userId { get; set; }
        public IFormFile curriculo { get; set; }
    }
}
