using RecruitmentPlatform.DTOs.Tecnologias;
using RecruitmentPlatform.Models;
using RecruitmentPlatform.Repository.IRepository;
using RecruitmentPlatform.Services.IService;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentPlatform.Services
{
    public class TecnologiasService : ITecnologiasService
    {
        private readonly ITecnologiasRepository _tecnologiasRepository;
        private readonly IMapper _mapper;

        public TecnologiasService(ITecnologiasRepository tecnologiasRepository, IMapper mapper)
        {
            _tecnologiasRepository = tecnologiasRepository;
            _mapper = mapper;
        }

        public async Task<TecnologiasDTO> CreateAsync(CreateTecnologiasDTO tecnologiasDTO)
        {
            var tecnologia = _mapper.Map<Tecnologias>(tecnologiasDTO);
            var createdTecnologia = await _tecnologiasRepository.CreateAsync(tecnologia);
            return _mapper.Map<TecnologiasDTO>(createdTecnologia);
        }

        public async Task<List<TecnologiasDTO>> GetAsync()
        {
            var tecnologiasList = await _tecnologiasRepository.GetAsync();
            return _mapper.Map<List<TecnologiasDTO>>(tecnologiasList);
        }

        public async Task<TecnologiasDTO> GetByIdAsync(Guid id)
        {
            var tecnologia = await _tecnologiasRepository.GetByIdAsync(id);
            return _mapper.Map<TecnologiasDTO>(tecnologia);
        }

        public async Task<TecnologiasDTO> UpdateAsync(UpdateTecnologiasDTO tecnologiasDTO)
        {
            var tecnologia = _mapper.Map<Tecnologias>(tecnologiasDTO);
            await _tecnologiasRepository.EditAsync(tecnologia);
            return _mapper.Map<TecnologiasDTO>(tecnologia);
        }
    }
}
