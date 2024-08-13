using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Zetta.DB.Migrations
{
    /// <inheritdoc />
    public partial class ObrasV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IncluyeMateriales",
                table: "Obras",
                newName: "InclMateriales");

            migrationBuilder.AddColumn<string>(
                name: "AnexarServicio",
                table: "Obras",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Materiales",
                table: "Obras",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnexarServicio",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "Materiales",
                table: "Obras");

            migrationBuilder.RenameColumn(
                name: "InclMateriales",
                table: "Obras",
                newName: "IncluyeMateriales");
        }
    }
}
