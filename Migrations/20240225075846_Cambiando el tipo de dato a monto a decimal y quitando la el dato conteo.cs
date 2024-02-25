using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial1_Ap1_RandyFabian.Migrations
{
    /// <inheritdoc />
    public partial class Cambiandoeltipodedatoamontoadecimalyquitandolaeldatoconteo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "conteo",
                table: "Metas");

            migrationBuilder.AlterColumn<decimal>(
                name: "Monto",
                table: "Metas",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Monto",
                table: "Metas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "conteo",
                table: "Metas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
