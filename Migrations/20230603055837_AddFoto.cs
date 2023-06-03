using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOS_Buscas_V2.Migrations
{
    /// <inheritdoc />
    public partial class AddFoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CaminhoImagem",
                table: "Desaparecidos",
                type: "nvarchar(100)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaminhoImagem",
                table: "Desaparecidos");
        }
    }
}
