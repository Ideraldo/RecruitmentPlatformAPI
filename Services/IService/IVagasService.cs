using RecruitmentPlatform.DTOs.Vagas;

namespace RecruitmentPlatform.Services.IService
{
    public interface IVagasService
    {
        Task<VagasDTO> CreateAsync(CreateVagasDTO userDTO);
        Task<List<VagasDTO>> GetAsync();
        Task<VagasDTO> GetByIdAsync(Guid id);
        Task<VagasDTO> UpdateAsync(UpdateVagasDTO useDTO);
    }
}
