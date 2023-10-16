using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Models;

namespace RecruitmentPlatform.Context.Mappers
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.LogoPath).HasMaxLength(250);
            builder.Property(e => e.Name).HasMaxLength(150).IsRequired();
        }
    }
}
