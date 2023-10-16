using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Context;
using RecruitmentPlatform.Mapper;
using RecruitmentPlatform.Repository;
using RecruitmentPlatform.Repository.IRepository;
using RecruitmentPlatform.Services;
using RecruitmentPlatform.Services.IService;

namespace RecruitmentPlatform.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var _connectionString = configuration.GetConnectionString("RecruitmentConnection");

            services.AddDbContext<DataContext>(options => options.UseMySql(_connectionString, new MySqlServerVersion(new Version("10.6.7"))));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<ISkillsRepository, SkillsRepository>();
            services.AddTransient<ITecnologiasRepository, TecnologiasRepository>();
            services.AddTransient<IVagasRepository, VagasRepository>();

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAutoMapper(typeof(DomainToDTO));
            services.AddAutoMapper(typeof(DomainToDTO), typeof(DtoToDomain));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<ISkillsService, SkillsService>();
            services.AddScoped<ITecnologiasService, TecnologiasService>();
            services.AddScoped<IVagasService, VagasService>();

            services.AddControllersWithViews();
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });

            return services;
        }
    }
}
