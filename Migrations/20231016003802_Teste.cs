using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentPlatform.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LogoPath = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PathCurriculo = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsRecruiter = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    EmpresaId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vagas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EmpresaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vagas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VagasId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Vagas_VagasId",
                        column: x => x.VagasId,
                        principalTable: "Vagas",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tecnologias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VagasId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnologias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tecnologias_Vagas_VagasId",
                        column: x => x.VagasId,
                        principalTable: "Vagas",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserVagas",
                columns: table => new
                {
                    UsersId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    VagasId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVagas", x => new { x.UsersId, x.VagasId });
                    table.ForeignKey(
                        name: "FK_UserVagas_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVagas_Vagas_VagasId",
                        column: x => x.VagasId,
                        principalTable: "Vagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SkillsUser",
                columns: table => new
                {
                    SkillsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsersId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsUser", x => new { x.SkillsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_SkillsUser_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillsUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TecnologiasUser",
                columns: table => new
                {
                    TecnologiasId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UsersId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecnologiasUser", x => new { x.TecnologiasId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TecnologiasUser_Tecnologias_TecnologiasId",
                        column: x => x.TecnologiasId,
                        principalTable: "Tecnologias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TecnologiasUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "Id", "IsActive", "LogoPath", "Name" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222222"), true, "path/to/logo1.png", "Empresa Exemplo 1" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), true, "path/to/logo2.png", "Empresa Exemplo 2" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Descricao", "Nome", "VagasId" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Habilidade de se comunicar de forma clara e eficaz.", "Comunicação", null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Habilidade de trabalhar bem em grupos e equipes.", "Trabalho em equipe", null }
                });

            migrationBuilder.InsertData(
                table: "Tecnologias",
                columns: new[] { "Id", "Descricao", "Name", "VagasId" },
                values: new object[,]
                {
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Framework de desenvolvimento para criação de aplicações web, desktop e mobile.", ".NET Core", null },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Linguagem de programação utilizada para desenvolvimento web.", "JavaScript", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cpf", "Email", "EmpresaId", "IsActive", "IsRecruiter", "Name", "PathCurriculo", "Senha" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "12345678901", "example@email.com", null, true, false, "John Doe", null, "hashed_password" });

            migrationBuilder.InsertData(
                table: "Vagas",
                columns: new[] { "Id", "EmpresaId" },
                values: new object[] { new Guid("88888888-8888-8888-8888-888888888888"), new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_VagasId",
                table: "Skills",
                column: "VagasId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsUser_UsersId",
                table: "SkillsUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Tecnologias_VagasId",
                table: "Tecnologias",
                column: "VagasId");

            migrationBuilder.CreateIndex(
                name: "IX_TecnologiasUser_UsersId",
                table: "TecnologiasUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmpresaId",
                table: "Users",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVagas_VagasId",
                table: "UserVagas",
                column: "VagasId");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_EmpresaId",
                table: "Vagas",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillsUser");

            migrationBuilder.DropTable(
                name: "TecnologiasUser");

            migrationBuilder.DropTable(
                name: "UserVagas");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Tecnologias");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vagas");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
