using AutoMapper;
using RecruitmentPlatform.DTOs.Empresa;
using RecruitmentPlatform.Models;
using RecruitmentPlatform.Repository.IRepository;
using RecruitmentPlatform.Services.IService;

namespace RecruitmentPlatform.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public async Task<EmpresaDTO> CreateAsync(CreateEmpresaDTO empresaDTO)
        {
            var empresa = _mapper.Map<Empresa>(empresaDTO);
            var createdEmpresa = await _empresaRepository.CreateAsync(empresa);
            return _mapper.Map<EmpresaDTO>(createdEmpresa);
        }

        public async Task<List<EmpresaDTO>> GetAsync()
        {
            var empresas = await _empresaRepository.GetAsync();
            return _mapper.Map<List<EmpresaDTO>>(empresas);
        }

        public async Task<EmpresaDTO> GetByIdAsync(Guid id)
        {
            var empresa = await _empresaRepository.GetByIdAsync(id);
            return _mapper.Map<EmpresaDTO>(empresa);
        }

        public async Task<EmpresaDTO> UpdateAsync(UpdateEmpresaDTO empresaDTO)
        {
            var empresa = _mapper.Map<Empresa>(empresaDTO);
            await _empresaRepository.EditAsync(empresa);
            return _mapper.Map<EmpresaDTO>(empresa);
        }
    }
}
