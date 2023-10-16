using AutoMapper;
using RecruitmentPlatform.DTOs.Vagas;
using RecruitmentPlatform.Models;
using RecruitmentPlatform.Repository.IRepository;
using RecruitmentPlatform.Services.IService;

namespace RecruitmentPlatform.Services
{
    public class VagasService : IVagasService
    {
        private readonly IVagasRepository _vagasRepository;
        private readonly IMapper _mapper;

        public VagasService(IVagasRepository vagasRepository, IMapper mapper)
        {
            _vagasRepository = vagasRepository;
            _mapper = mapper;
        }

        public async Task<VagasDTO> CreateAsync(CreateVagasDTO vagasDTO)
        {
            var vaga = _mapper.Map<Vagas>(vagasDTO);
            var createdVaga = await _vagasRepository.CreateAsync(vaga);
            return _mapper.Map<VagasDTO>(createdVaga);
        }

        public async Task<List<VagasDTO>> GetAsync()
        {
            var vagasList = await _vagasRepository.GetAsync();
            return _mapper.Map<List<VagasDTO>>(vagasList);
        }

        public async Task<VagasDTO> GetByIdAsync(Guid id)
        {
            var vaga = await _vagasRepository.GetByIdAsync(id);
            return _mapper.Map<VagasDTO>(vaga);
        }

        public async Task<VagasDTO> UpdateAsync(UpdateVagasDTO vagasDTO)
        {
            var vaga = _mapper.Map<Vagas>(vagasDTO);
            await _vagasRepository.EditAsync(vaga);
            return _mapper.Map<VagasDTO>(vaga);
        }
    }
}
