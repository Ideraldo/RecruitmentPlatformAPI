using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Models;

namespace RecruitmentPlatform.Context.Mappers
{
    public class TecnologiasConfiguration : IEntityTypeConfiguration<Tecnologias>
    {
        public void Configure(EntityTypeBuilder<Tecnologias> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).HasMaxLength(150).IsRequired();
            builder.Property(t => t.Descricao).HasMaxLength(500);
        }
    }
}
