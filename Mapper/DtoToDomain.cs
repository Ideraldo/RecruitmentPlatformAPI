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
    public class DtoToDomain : Profile
    {
        public DtoToDomain()
        {
            // User Mappings
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Skills, opt =>
                {
                    opt.PreCondition(src => src.Skills != null); // Verifica se SkillsIds não é nulo
                    opt.MapFrom(src => src.Skills.Select(id => new Skills { Id = id }));
                })
                .ForMember(dest => dest.Tecnologias, opt =>
                {
                    opt.PreCondition(src => src.Tecnologias != null); // Verifica se TecnologiasIds não é nulo
                    opt.MapFrom(src => src.Tecnologias.Select(id => new Tecnologias { Id = id }));
                })
                .ForMember(dest => dest.Vagas, opt =>
                {
                    opt.PreCondition(src => src.Vagas != null); // Verifica se VagasIds não é nulo
                    opt.MapFrom(src => src.Vagas.Select(id => new Vagas { Id = id }));
                });

            CreateMap<CreateUserDTO, User>()
                .ForMember(dest => dest.Skills, opt =>
                {
                    opt.PreCondition(src => src.Skills != null);
                    opt.MapFrom(src => src.Skills.Select(id => new Skills { Id = id }));
                })
                .ForMember(dest => dest.Tecnologias, opt =>
                {
                    opt.PreCondition(src => src.Tecnologias != null);
                    opt.MapFrom(src => src.Tecnologias.Select(id => new Tecnologias { Id = id }));
                });

            CreateMap<UpdateUserDTO, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora ID durante a atualização, se necessário
                .ForMember(dest => dest.Senha, opt => opt.Ignore()) // Ignora Senha durante a atualização, se necessário
                .ForMember(dest => dest.Skills, opt =>
                {
                    opt.PreCondition(src => src.Skills != null);
                    opt.MapFrom(src => src.Skills.Select(id => new Skills { Id = id }));
                })
                .ForMember(dest => dest.Tecnologias, opt =>
                {
                    opt.PreCondition(src => src.Tecnologias != null);
                    opt.MapFrom(src => src.Tecnologias.Select(id => new Tecnologias { Id = id }));
                })
                .ForMember(dest => dest.Vagas, opt =>
                {
                    opt.PreCondition(src => src.Vagas != null);
                    opt.MapFrom(src => src.Vagas.Select(id => new Vagas { Id = id }));
                });


            // Empresa Mappings
            CreateMap<EmpresaDTO, Empresa>();
            CreateMap<CreateEmpresaDTO, Empresa>();
            CreateMap<UpdateEmpresaDTO, Empresa>();

            // Skills Mappings
            CreateMap<SkillsDTO, Skills>();
            CreateMap<CreateSkillsDTO, Skills>();
            CreateMap<UpdateSkillsDTO, Skills>();

            // Tecnologias Mappings
            CreateMap<TecnologiasDTO, Tecnologias>();
            CreateMap<CreateTecnologiasDTO, Tecnologias>();
            CreateMap<UpdateTecnologiasDTO, Tecnologias>();

            // Vagas Mappings
            CreateMap<VagasDTO, Vagas>();
            CreateMap<CreateVagasDTO, Vagas>()
                .ForMember(dest => dest.SkillsNecessarias, opt =>
                {
                    opt.PreCondition(src => src.SkillsNecessarias != null); // Verifica se SkillsNecessarias não é nulo
                    opt.MapFrom(src => src.SkillsNecessarias.Select(skillId => new Skills { Id = skillId }));
                })
                .ForMember(dest => dest.Tecnologias, opt =>
                {
                    opt.PreCondition(src => src.Tecnologias != null); // Verifica se Tecnologias não é nulo
                    opt.MapFrom(src => src.Tecnologias.Select(tecnologiaId => new Tecnologias { Id = tecnologiaId }));
                });

            CreateMap<UpdateVagasDTO, Vagas>()
                .ForMember(dest => dest.SkillsNecessarias, opt =>
                {
                    opt.PreCondition(src => src.SkillsNecessarias != null); // Verifica se SkillsNecessarias não é nulo
                    opt.MapFrom(src => src.SkillsNecessarias.Select(skillId => new Skills { Id = skillId }));
                })
                .ForMember(dest => dest.Tecnologias, opt =>
                {
                    opt.PreCondition(src => src.Tecnologias != null); // Verifica se Tecnologias não é nulo
                    opt.MapFrom(src => src.Tecnologias.Select(tecnologiaId => new Tecnologias { Id = tecnologiaId }));
                });
        }
    }
}
