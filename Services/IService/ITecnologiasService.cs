using RecruitmentPlatform.DTOs.Tecnologias;

namespace RecruitmentPlatform.Services.IService
{
    public interface ITecnologiasService
    {
        Task<TecnologiasDTO> CreateAsync(CreateTecnologiasDTO userDTO);
        Task<List<TecnologiasDTO>> GetAsync();
        Task<TecnologiasDTO> GetByIdAsync(Guid id);
        Task<TecnologiasDTO> UpdateAsync(UpdateTecnologiasDTO useDTO);
    }
}
