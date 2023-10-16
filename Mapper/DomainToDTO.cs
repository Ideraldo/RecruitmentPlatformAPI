using AutoMapper;
using RecruitmentPlatform.DTOs;
using RecruitmentPlatform.DTOs.Empresa;
using RecruitmentPlatform.DTOs.Skills;
using RecruitmentPlatform.DTOs.Tecnologias;
using RecruitmentPlatform.DTOs.User;
using RecruitmentPlatform.DTOs.Vagas;
using RecruitmentPlatform.Models;

namespace RecruitmentPlatform.Mapper
{
    public class DomainToDTO : Profile
    {
        public DomainToDTO()
        {
            // User Mappings
            CreateMap<User, UserDTO>()
                    .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills.Select(s => s.Id)))
                    .ForMember(dest => dest.Tecnologias, opt => opt.MapFrom(src => src.Tecnologias.Select(s => s.Id)))
                    .ForMember(dest => dest.Vagas, opt => opt.MapFrom(src => src.Vagas.Select(s => s.Id)));

            CreateMap<User, CreateUserDTO>()
                .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills.Select(s => s.Id)))
                .ForMember(dest => dest.Tecnologias, opt => opt.MapFrom(src => src.Tecnologias.Select(s => s.Id)));

            CreateMap<User, UpdateUserDTO>()
                    .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills.Select(s => s.Id)))
                    .ForMember(dest => dest.Tecnologias, opt => opt.MapFrom(src => src.Tecnologias.Select(s => s.Id)))
                    .ForMember(dest => dest.Vagas, opt => opt.MapFrom(src => src.Vagas.Select(s => s.Id)));

            // Empresa Mappings
            CreateMap<Empresa, EmpresaDTO>();
            CreateMap<Empresa, CreateEmpresaDTO>();
            CreateMap<Empresa, UpdateEmpresaDTO>();

            // Skills Mappings
            CreateMap<Skills, SkillsDTO>();
            CreateMap<Skills, CreateSkillsDTO>();
            CreateMap<Skills, UpdateSkillsDTO>();

            // Tecnologias Mappings
            CreateMap<Tecnologias, TecnologiasDTO>();
            CreateMap<Tecnologias, CreateTecnologiasDTO>();
            CreateMap<Tecnologias, UpdateTecnologiasDTO>();

            // Mapeamento de Vagas para VagasDTO
            CreateMap<Vagas, VagasDTO>()
                .ForMember(dest => dest.Empresa, opt => opt.MapFrom(src => src.Empresa)) // Mapeando a propriedade Empresa
                .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom(src => src.EmpresaId)) // Mapeando a propriedade EmpresaId
                .ForMember(dest => dest.SkillsNecessarias, opt => opt.MapFrom(src => src.SkillsNecessarias)) // Mapeando a propriedade SkillsNecessarias
                .ForMember(dest => dest.Tecnologias, opt => opt.MapFrom(src => src.Tecnologias)) // Mapeando a propriedade Tecnologias
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users)); // Mapeando a propriedade Users


            // Mapeamento de Vagas para CreateVagasDTO
            CreateMap<Vagas, CreateVagasDTO>()
                .ForMember(dest => dest.SkillsNecessarias, opt => opt.MapFrom(src => src.SkillsNecessarias.Select(s => s.Id)))
                .ForMember(dest => dest.Tecnologias, opt => opt.MapFrom(src => src.Tecnologias.Select(t => t.Id)));

            // Mapeamento de Vagas para UpdateVagasDTO
            CreateMap<Vagas, UpdateVagasDTO>()
                .ForMember(dest => dest.SkillsNecessarias, opt => opt.MapFrom(src => src.SkillsNecessarias.Select(s => s.Id)))
                .ForMember(dest => dest.Tecnologias, opt => opt.MapFrom(src => src.Tecnologias.Select(t => t.Id)));

        }
    }
}
