using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Turismos.Api.Migrations
{
    /// <inheritdoc />
    public partial class CreacionIndexClienteParaCedula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Cedula",
                table: "Clientes",
                column: "Cedula",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_Cedula",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Edad",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
