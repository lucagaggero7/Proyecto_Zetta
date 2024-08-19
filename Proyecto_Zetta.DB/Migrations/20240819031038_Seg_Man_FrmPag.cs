using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Zetta.DB.Migrations
{
    /// <inheritdoc />
    public partial class Seg_Man_FrmPag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Clientes_ClienteId",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Obras_ClienteId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "FormadePago",
                table: "Presupuestos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "FechaMantenimiento",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "InclMateriales",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "Mantenimiento",
                table: "Obras");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Presupuestos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Forma_de_PagoId",
                table: "Presupuestos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Obras",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

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

            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaVisita = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PresupuestoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Presupuestos_PresupuestoId",
                        column: x => x.PresupuestoId,
                        principalTable: "Presupuestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seguimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mantenimiento_SN = table.Column<bool>(type: "bit", nullable: false),
                    ObraId = table.Column<int>(type: "int", nullable: false),
                    MantenimientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seguimientos_Mantenimientos_MantenimientoId",
                        column: x => x.MantenimientoId,
                        principalTable: "Mantenimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seguimientos_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Presupuestos_ClienteId",
                table: "Presupuestos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Presupuestos_Forma_de_PagoId",
                table: "Presupuestos",
                column: "Forma_de_PagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_PresupuestoId",
                table: "Mantenimientos",
                column: "PresupuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguimientos_MantenimientoId",
                table: "Seguimientos",
                column: "MantenimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguimientos_ObraId",
                table: "Seguimientos",
                column: "ObraId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presupuestos_Clientes_ClienteId",
                table: "Presupuestos");

            migrationBuilder.DropForeignKey(
                name: "FK_Presupuestos_Formas_De_Pago_Forma_de_PagoId",
                table: "Presupuestos");

            migrationBuilder.DropTable(
                name: "Formas_De_Pago");

            migrationBuilder.DropTable(
                name: "Seguimientos");

            migrationBuilder.DropTable(
                name: "Mantenimientos");

            migrationBuilder.DropIndex(
                name: "IX_Presupuestos_ClienteId",
                table: "Presupuestos");

            migrationBuilder.DropIndex(
                name: "IX_Presupuestos_Forma_de_PagoId",
                table: "Presupuestos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Presupuestos");

            migrationBuilder.DropColumn(
                name: "Forma_de_PagoId",
                table: "Presupuestos");

            migrationBuilder.AddColumn<string>(
                name: "FormadePago",
                table: "Presupuestos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Obras",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Obras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaMantenimiento",
                table: "Obras",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InclMateriales",
                table: "Obras",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mantenimiento",
                table: "Obras",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_ClienteId",
                table: "Obras",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Clientes_ClienteId",
                table: "Obras",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
