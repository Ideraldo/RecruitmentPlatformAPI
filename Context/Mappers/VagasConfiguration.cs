using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Models;

namespace RecruitmentPlatform.Context.Mappers
{
    public class VagasConfiguration : IEntityTypeConfiguration<Vagas>
    {
        public void Configure(EntityTypeBuilder<Vagas> builder)
        {
            builder.HasKey(v => v.Id);

            // Relação com a entidade Empresa
            builder.HasOne(v => v.Empresa)
                   .WithMany() // Se Empresa tiver uma coleção de Vagas, substitua por .WithMany(e => e.Vagas)
                   .IsRequired();

            // Relações com outras entidades (Skills e Tecnologias) podem ser definidas aqui, se necessário
        }
    }
}
