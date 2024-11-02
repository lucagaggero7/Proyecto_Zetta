using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Zetta.DB.Migrations
{
    /// <inheritdoc />
    public partial class ReconstruccionEv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presupuestos_Clientes_ClienteId",
                table: "Presupuestos");

            migrationBuilder.DropForeignKey(
                name: "FK_Presupuestos_Formas_De_Pago_Forma_de_PagoId",
                table: "Presupuestos");

            migrationBuilder.DropForeignKey(
                name: "FK_Seguimientos_Mantenimientos_MantenimientoId",
                table: "Seguimientos");

            migrationBuilder.DropTable(
                name: "Formas_De_Pago");

            migrationBuilder.DropIndex(
                name: "IX_Seguimientos_MantenimientoId",
                table: "Seguimientos");

            migrationBuilder.DropColumn(
                name: "MantenimientoId",
                table: "Seguimientos");

            migrationBuilder.DropColumn(
                name: "Materiales",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Obras");

            migrationBuilder.RenameColumn(
                name: "Mantenimiento_SN",
                table: "Seguimientos",
                newName: "MantenimientoIncl");

            migrationBuilder.RenameColumn(
                name: "Forma_de_PagoId",
                table: "Presupuestos",
                newName: "ItemTipoId");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Presupuestos",
                newName: "FormadePagoId");

            migrationBuilder.RenameIndex(
                name: "IX_Presupuestos_Forma_de_PagoId",
                table: "Presupuestos",
                newName: "IX_Presupuestos_ItemTipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Presupuestos_ClienteId",
                table: "Presupuestos",
                newName: "IX_Presupuestos_FormadePagoId");

            migrationBuilder.AddColumn<bool>(
                name: "MaterialesIncl",
                table: "Presupuestos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Presupuestos",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Obras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeguimientoId",
                table: "Mantenimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FormasDePago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasDePago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemsTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Insumos = table.Column<long>(type: "bigint", nullable: false),
                    ManodeObra = table.Column<long>(type: "bigint", nullable: false),
                    PrecioFinal = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UnidadMedida = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Precio = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemsTipoMateriales",
                columns: table => new
                {
                    ItemTipoId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsTipoMateriales", x => new { x.ItemTipoId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_ItemsTipoMateriales_ItemsTipo_ItemTipoId",
                        column: x => x.ItemTipoId,
                        principalTable: "ItemsTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemsTipoMateriales_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Obras_ClienteId",
                table: "Obras",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_SeguimientoId",
                table: "Mantenimientos",
                column: "SeguimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsTipoMateriales_MaterialId",
                table: "ItemsTipoMateriales",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimientos_Seguimientos_SeguimientoId",
                table: "Mantenimientos",
                column: "SeguimientoId",
                principalTable: "Seguimientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Clientes_ClienteId",
                table: "Obras",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Presupuestos_FormasDePago_FormadePagoId",
                table: "Presupuestos",
                column: "FormadePagoId",
                principalTable: "FormasDePago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Presupuestos_ItemsTipo_ItemTipoId",
                table: "Presupuestos",
                column: "ItemTipoId",
                principalTable: "ItemsTipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimientos_Seguimientos_SeguimientoId",
                table: "Mantenimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Clientes_ClienteId",
                table: "Obras");

            migrationBuilder.DropForeignKey(
                name: "FK_Presupuestos_FormasDePago_FormadePagoId",
                table: "Presupuestos");

            migrationBuilder.DropForeignKey(
                name: "FK_Presupuestos_ItemsTipo_ItemTipoId",
                table: "Presupuestos");

            migrationBuilder.DropTable(
                name: "FormasDePago");

            migrationBuilder.DropTable(
                name: "ItemsTipoMateriales");

            migrationBuilder.DropTable(
                name: "ItemsTipo");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropIndex(
                name: "IX_Obras_ClienteId",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Mantenimientos_SeguimientoId",
                table: "Mantenimientos");

            migrationBuilder.DropColumn(
                name: "MaterialesIncl",
                table: "Presupuestos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Presupuestos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "SeguimientoId",
                table: "Mantenimientos");

            migrationBuilder.RenameColumn(
                name: "MantenimientoIncl",
                table: "Seguimientos",
                newName: "Mantenimiento_SN");

            migrationBuilder.RenameColumn(
                name: "ItemTipoId",
                table: "Presupuestos",
                newName: "Forma_de_PagoId");

            migrationBuilder.RenameColumn(
                name: "FormadePagoId",
                table: "Presupuestos",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Presupuestos_ItemTipoId",
                table: "Presupuestos",
                newName: "IX_Presupuestos_Forma_de_PagoId");

            migrationBuilder.RenameIndex(
                name: "IX_Presupuestos_FormadePagoId",
                table: "Presupuestos",
                newName: "IX_Presupuestos_ClienteId");

            migrationBuilder.AddColumn<int>(
                name: "MantenimientoId",
                table: "Seguimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Materiales",
                table: "Obras",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Obras",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Formas_De_Pago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formas_De_Pago", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seguimientos_MantenimientoId",
                table: "Seguimientos",
                column: "MantenimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Presupuestos_Clientes_ClienteId",
                table: "Presupuestos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Presupuestos_Formas_De_Pago_Forma_de_PagoId",
                table: "Presupuestos",
                column: "Forma_de_PagoId",
                principalTable: "Formas_De_Pago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seguimientos_Mantenimientos_MantenimientoId",
                table: "Seguimientos",
                column: "MantenimientoId",
                principalTable: "Mantenimientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
