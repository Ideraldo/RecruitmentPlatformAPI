﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecruitmentPlatform.Context;

#nullable disable

namespace RecruitmentPlatform.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RecruitmentPlatform.Models.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LogoPath")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");

                    b.HasData(
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            IsActive = true,
                            LogoPath = "path/to/logo1.png",
                            Name = "Empresa Exemplo 1"
                        },
                        new
                        {
                            Id = new Guid("33333333-3333-3333-3333-333333333333"),
                            IsActive = true,
                            LogoPath = "path/to/logo2.png",
                            Name = "Empresa Exemplo 2"
                        });
                });

            modelBuilder.Entity("RecruitmentPlatform.Models.Skills", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<Guid?>("VagasId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("VagasId");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = new Guid("44444444-4444-4444-4444-444444444444"),
                            Descricao = "Habilidade de se comunicar de forma clara e eficaz.",
                            Nome = "Comunicação"
                        },
                        new
                        {
                            Id = new Guid("55555555-5555-5555-5555-555555555555"),
                            Descricao = "Habilidade de trabalhar bem em grupos e equipes.",
                            Nome = "Trabalho em equipe"
                        });
                });

            modelBuilder.Entity("RecruitmentPlatform.Models.Tecnologias", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<Guid?>("VagasId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("VagasId");

                    b.ToTable("Tecnologias");

                    b.HasData(
                        new
                        {
                            Id = new Guid("66666666-6666-6666-6666-666666666666"),
                            Descricao = "Framework de desenvolvimento para criação de aplicações web, desktop e mobile.",
                            Name = ".NET Core"
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777777777"),
                            Descricao = "Linguagem de programação utilizada para desenvolvimento web.",
                            Name = "JavaScript"
                        });
                });

            modelBuilder.Entity("RecruitmentPlatform.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Cpf")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("EmpresaId")
                        .HasColumnType("char(36)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsRecruiter")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("PathCurriculo")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Senha")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            Cpf = "12345678901",
                            Email = "example@email.com",
                            IsActive = true,
                            IsRecruiter = false,
                            Name = "John Doe",
                            Senha = "hashed_password"
                        });
                });

            modelBuilder.Entity("RecruitmentPlatform.Models.Vagas", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("EmpresaId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Vagas");

                    b.HasData(
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888888888"),
                            EmpresaId = new Guid("22222222-2222-2222-2222-222222222222")
                        });
                });

            modelBuilder.Entity("SkillsUser", b =>
                {
                    b.Property<Guid>("SkillsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("char(36)");

                    b.HasKey("SkillsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("SkillsUser");
                });

            modelBuilder.Entity("TecnologiasUser", b =>
                {
                    b.Property<Guid>("TecnologiasId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("char(36)");

                    b.HasKey("TecnologiasId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("TecnologiasUser");
                });

            modelBuilder.Entity("UserVagas", b =>
                {
                    b.Property<Guid>("UsersId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("VagasId")
                        .HasColumnType("char(36)");

                    b.HasKey("UsersId", "VagasId");

                    b.HasIndex("VagasId");

                    b.ToTable("UserVagas");
                });

            modelBuilder.Entity("RecruitmentPlatform.Models.Skills", b =>
                {
                    b.HasOne("RecruitmentPlatform.Models.Vagas", null)
                        .WithMany("SkillsNecessarias")
                        .HasForeignKey("VagasId");
                });

            modelBuilder.Entity("RecruitmentPlatform.Models.Tecnologias", b =>
                {
                    b.HasOne("RecruitmentPlatform.Models.Vagas", null)
                        .WithMany("Tecnologias")
                        .HasForeignKey("VagasId");
                });

            modelBuilder.Entity("RecruitmentPlatform.Models.User", b =>
                {
                    b.HasOne("RecruitmentPlatform.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("RecruitmentPlatform.Models.Vagas", b =>
                {
                    b.HasOne("RecruitmentPlatform.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("SkillsUser", b =>
                {
                    b.HasOne("RecruitmentPlatform.Models.Skills", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentPlatform.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TecnologiasUser", b =>
                {
                    b.HasOne("RecruitmentPlatform.Models.Tecnologias", null)
                        .WithMany()
                        .HasForeignKey("TecnologiasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentPlatform.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserVagas", b =>
                {
                    b.HasOne("RecruitmentPlatform.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecruitmentPlatform.Models.Vagas", null)
                        .WithMany()
                        .HasForeignKey("VagasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecruitmentPlatform.Models.Vagas", b =>
                {
                    b.Navigation("SkillsNecessarias");

                    b.Navigation("Tecnologias");
                });
#pragma warning restore 612, 618
        }
    }
}
