using RecruitmentPlatform.DTOs.Empresa;

namespace RecruitmentPlatform.Services.IService
{
    public interface IEmpresaService
    {
        Task<EmpresaDTO> CreateAsync(CreateEmpresaDTO userDTO);
        Task<List<EmpresaDTO>> GetAsync();
        Task<EmpresaDTO> GetByIdAsync(Guid id);
        Task<EmpresaDTO> UpdateAsync(UpdateEmpresaDTO useDTO);
    }
}
