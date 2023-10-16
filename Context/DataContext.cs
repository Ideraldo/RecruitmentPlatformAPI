using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Context.Mappers;
using RecruitmentPlatform.Models;

namespace RecruitmentPlatform.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql($"Server=localhost;Database=RecruitmentPlatform;Uid=root;Pwd=root;", new MySqlServerVersion(new Version("10.6.7")));
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Tecnologias> Tecnologias { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Vagas> Vagas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new SkillsConfiguration());
            modelBuilder.ApplyConfiguration(new TecnologiasConfiguration());
            modelBuilder.ApplyConfiguration(new VagasConfiguration());

            modelBuilder.Seed();
        }
    }
}
