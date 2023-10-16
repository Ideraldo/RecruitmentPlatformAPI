using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitmentPlatform.Models;

namespace RecruitmentPlatform.Context.Mappers
{
    public class SkillsConfiguration : IEntityTypeConfiguration<Skills>
    {
        public void Configure(EntityTypeBuilder<Skills> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Nome).HasMaxLength(150).IsRequired();
            builder.Property(s => s.Descricao).HasMaxLength(500);
        }
    }
}
