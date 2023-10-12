using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Turismos.Api.Migrations
{
    /// <inheritdoc />
    public partial class relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Viajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransporteId",
                table: "Viajes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoPagoId",
                table: "Facturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ComentarioId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacturaId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ViajeId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_HotelId",
                table: "Viajes",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_TransporteId",
                table: "Viajes",
                column: "TransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_TipoPagoId",
                table: "Facturas",
                column: "TipoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ComentarioId",
                table: "Clientes",
                column: "ComentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_FacturaId",
                table: "Clientes",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ViajeId",
                table: "Clientes",
                column: "ViajeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Comentarios_ComentarioId",
                table: "Clientes",
                column: "ComentarioId",
                principalTable: "Comentarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Facturas_FacturaId",
                table: "Clientes",
                column: "FacturaId",
                principalTable: "Facturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Viajes_ViajeId",
                table: "Clientes",
                column: "ViajeId",
                principalTable: "Viajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_TipoPagos_TipoPagoId",
                table: "Facturas",
                column: "TipoPagoId",
                principalTable: "TipoPagos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_Hotels_HotelId",
                table: "Viajes",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Viajes_Transportes_TransporteId",
                table: "Viajes",
                column: "TransporteId",
                principalTable: "Transportes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Comentarios_ComentarioId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Facturas_FacturaId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Viajes_ViajeId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_TipoPagos_TipoPagoId",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_Hotels_HotelId",
                table: "Viajes");

            migrationBuilder.DropForeignKey(
                name: "FK_Viajes_Transportes_TransporteId",
                table: "Viajes");

            migrationBuilder.DropIndex(
                name: "IX_Viajes_HotelId",
                table: "Viajes");

            migrationBuilder.DropIndex(
                name: "IX_Viajes_TransporteId",
                table: "Viajes");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_TipoPagoId",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ComentarioId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_FacturaId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ViajeId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "TransporteId",
                table: "Viajes");

            migrationBuilder.DropColumn(
                name: "TipoPagoId",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "ComentarioId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "FacturaId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ViajeId",
                table: "Clientes");
        }
    }
}
