using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alquiler_Autos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class RelacionPagoReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pagos_IdReserva",
                table: "Pagos",
                column: "IdReserva");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Reservas_IdReserva",
                table: "Pagos",
                column: "IdReserva",
                principalTable: "Reservas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Reservas_IdReserva",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_IdReserva",
                table: "Pagos");
        }
    }
}
