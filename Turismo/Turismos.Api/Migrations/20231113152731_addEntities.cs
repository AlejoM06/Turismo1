using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Turismos.Api.Migrations
{
    /// <inheritdoc />
    public partial class addEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_Hotels_HotelId",
                table: "Viajes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotels",
                table: "Hotels");

            migrationBuilder.RenameTable(
                name: "Hotels",
                newName: "Hoteles");

            migrationBuilder.AddColumn<int>(
                name: "TransporteId",
                table: "Facturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hoteles",
                table: "Hoteles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_TransporteId",
                table: "Facturas",
                column: "TransporteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Transportes_TransporteId",
                table: "Facturas",
                column: "TransporteId",
                principalTable: "Transportes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_Hoteles_HotelId",
                table: "Viajes",
                column: "HotelId",
                principalTable: "Hoteles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Transportes_TransporteId",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_Hoteles_HotelId",
                table: "Viajes");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_TransporteId",
                table: "Facturas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hoteles",
                table: "Hoteles");

            migrationBuilder.DropColumn(
                name: "TransporteId",
                table: "Facturas");

            migrationBuilder.RenameTable(
                name: "Hoteles",
                newName: "Hotels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotels",
                table: "Hotels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_Hotels_HotelId",
                table: "Viajes",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
