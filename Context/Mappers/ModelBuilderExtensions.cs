using System;
using Microsoft.EntityFrameworkCore;
using RecruitmentPlatform.Models;

namespace RecruitmentPlatform.Context.Mappers
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // IDs estáticos
            var userId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var empresa1Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var empresa2Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var skill1Id = Guid.Parse("44444444-4444-4444-4444-444444444444");
            var skill2Id = Guid.Parse("55555555-5555-5555-5555-555555555555");
            var tecnologia1Id = Guid.Parse("66666666-6666-6666-6666-666666666666");
            var tecnologia2Id = Guid.Parse("77777777-7777-7777-7777-777777777777");
            var vagaId = Guid.Parse("88888888-8888-8888-8888-888888888888");

            // Dados iniciais para User
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId,
                    Email = "example@email.com",
                    Senha = "hashed_password", // Use a senha hash aqui
                    Name = "John Doe",
                    Cpf = "12345678901",
                    IsRecruiter = false,
                    IsActive = true,
                    // Adicione outros campos conforme necessário
                }
            );

            // Dados iniciais para Empresa
            modelBuilder.Entity<Empresa>().HasData(
                new Empresa
                {
                    Id = empresa1Id,
                    LogoPath = "path/to/logo1.png",
                    Name = "Empresa Exemplo 1",
                    IsActive = true
                },
                new Empresa
                {
                    Id = empresa2Id,
                    LogoPath = "path/to/logo2.png",
                    Name = "Empresa Exemplo 2",
                    IsActive = true
                }
            );

            // Dados iniciais para Skills
            modelBuilder.Entity<Skills>().HasData(
                new Skills
                {
                    Id = skill1Id,
                    Nome = "Comunicação",
                    Descricao = "Habilidade de se comunicar de forma clara e eficaz."
                },
                new Skills
                {
                    Id = skill2Id,
                    Nome = "Trabalho em equipe",
                    Descricao = "Habilidade de trabalhar bem em grupos e equipes."
                }
            );

            // Dados iniciais para Tecnologias
            modelBuilder.Entity<Tecnologias>().HasData(
                new Tecnologias
                {
                    Id = tecnologia1Id,
                    Name = ".NET Core",
                    Descricao = "Framework de desenvolvimento para criação de aplicações web, desktop e mobile."
                },
                new Tecnologias
                {
                    Id = tecnologia2Id,
                    Name = "JavaScript",
                    Descricao = "Linguagem de programação utilizada para desenvolvimento web."
                }
            );

            // Dados iniciais para Vagas
            modelBuilder.Entity<Vagas>().HasData(
                new Vagas
                {
                    Id = vagaId,
                    EmpresaId = empresa1Id
                    // Adicione outros campos conforme necessário
                }
            );
        }
    }
}
