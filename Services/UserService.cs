using AutoMapper;
using RecruitmentPlatform.DTOs.User;
using RecruitmentPlatform.Models;
using RecruitmentPlatform.Repository.IRepository;
using RecruitmentPlatform.Services.IService;

namespace RecruitmentPlatform.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDTO> CreateAsync(CreateUserDTO userDTO)
        {
            if (userDTO == null) throw new ArgumentNullException();
            var user = _mapper.Map<User>(userDTO);
            var data = await _userRepository.CreateAsync(user);
            return _mapper.Map<UserDTO>(data);
        }

        public async Task<List<UserDTO>> GetAsync()
        {
            var data = await _userRepository.GetUserAsync();
            return _mapper.Map<List<UserDTO>>(data);
        }

        public async Task<UserDTO> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdateAsync(UpdateUserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            await _userRepository.EditAsync(user);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> AddCurriculoAsync(AddCurriculoDTO curriculoDTO)
        {
            var filepath = Path.Combine("Curriculos", curriculoDTO.curriculo.FileName);
            using (Stream fileStream = new FileStream(filepath, FileMode.Create))
            {
                await curriculoDTO.curriculo.CopyToAsync(fileStream);
            }

            var user = await _userRepository.GetByIdAsync(curriculoDTO.userId);
            user.PathCurriculo = filepath;
            await _userRepository.EditAsync(user);
            return _mapper.Map<UserDTO>(user);
        }
    }
}
