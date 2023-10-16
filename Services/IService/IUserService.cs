using RecruitmentPlatform.DTOs.User;

namespace RecruitmentPlatform.Services.IService
{
    public interface IUserService
    {
        Task<UserDTO> CreateAsync(CreateUserDTO userDTO);
        Task<List<UserDTO>> GetAsync();
        Task<UserDTO> GetByIdAsync(Guid id);
        Task<UserDTO> UpdateAsync(UpdateUserDTO useDTO);
        Task<UserDTO> AddCurriculoAsync(AddCurriculoDTO curriculoDTO);


    }
}
