using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOS_Buscas_V2.Migrations
{
    /// <inheritdoc />
    public partial class Criandotabelas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Altura",
                table: "Desaparecidos",
                type: "varchar(5)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Altura",
                table: "Desaparecidos",
                type: "decimal(2,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldNullable: true);
        }
    }
}
