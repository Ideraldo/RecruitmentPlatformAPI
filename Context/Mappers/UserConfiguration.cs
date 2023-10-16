using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Models;

namespace RecruitmentPlatform.Context.Mappers
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.Senha).HasMaxLength(100);
            builder.Property(u => u.Name).HasMaxLength(150);
            builder.Property(u => u.Cpf).HasMaxLength(11);
            builder.Property(u => u.PathCurriculo).HasMaxLength(250);

            // Relações com outras entidades podem ser definidas aqui, se necessário
        }
    }
}
