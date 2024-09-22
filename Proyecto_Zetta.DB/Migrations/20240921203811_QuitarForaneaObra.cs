using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Zetta.DB.Migrations
{
    /// <inheritdoc />
    public partial class QuitarForaneaObra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Instaladores_InstaladorId",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Obras_InstaladorId",
                table: "Obras");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Obras_InstaladorId",
                table: "Obras",
                column: "InstaladorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Instaladores_InstaladorId",
                table: "Obras",
                column: "InstaladorId",
                principalTable: "Instaladores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
