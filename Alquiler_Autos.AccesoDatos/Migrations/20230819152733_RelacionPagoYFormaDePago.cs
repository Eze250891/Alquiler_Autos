using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alquiler_Autos.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class RelacionPagoYFormaDePago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Usuarios",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_IdFormaDePago",
                table: "Pagos",
                column: "IdFormaDePago");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_FormaDePagos_IdFormaDePago",
                table: "Pagos",
                column: "IdFormaDePago",
                principalTable: "FormaDePagos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_FormaDePagos_IdFormaDePago",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_IdFormaDePago",
                table: "Pagos");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }
    }
}
