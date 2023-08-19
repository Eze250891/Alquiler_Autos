using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alquiler_Autos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class RelacionReservaVehiculoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdTipoCombustible",
                table: "Vehiculos",
                column: "IdTipoCombustible");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdUsuario",
                table: "Reservas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdVehiculo",
                table: "Reservas",
                column: "IdVehiculo");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Usuarios_IdUsuario",
                table: "Reservas",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Vehiculos_IdVehiculo",
                table: "Reservas",
                column: "IdVehiculo",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculos_tipoCombustibles_IdTipoCombustible",
                table: "Vehiculos",
                column: "IdTipoCombustible",
                principalTable: "tipoCombustibles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Usuarios_IdUsuario",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Vehiculos_IdVehiculo",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculos_tipoCombustibles_IdTipoCombustible",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_IdTipoCombustible",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_IdUsuario",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_IdVehiculo",
                table: "Reservas");
        }
    }
}
