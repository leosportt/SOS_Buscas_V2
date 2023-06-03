using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOS_Buscas_V2.Migrations
{
    /// <inheritdoc />
    public partial class Criandotabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Email = table.Column<string>(type: "varchar(45)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(35)", nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(45)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(45)", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Desaparecidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(35)", nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(45)", nullable: false),
                    Roupa = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Estilocabelo = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CorPele = table.Column<string>(type: "varchar(15)", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(2,2)", nullable: true),
                    Tatoagem = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DataHoraDesaparecimento = table.Column<DateTime>(type: "DateTime", nullable: false),
                    EmailUsuario = table.Column<string>(type: "varchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desaparecidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desaparecidos_Usuarios_EmailUsuario",
                        column: x => x.EmailUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desaparecidos_EmailUsuario",
                table: "Desaparecidos",
                column: "EmailUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desaparecidos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
