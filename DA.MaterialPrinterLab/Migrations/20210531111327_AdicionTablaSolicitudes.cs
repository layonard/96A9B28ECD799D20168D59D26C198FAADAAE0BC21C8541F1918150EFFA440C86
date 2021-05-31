using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DA.MaterialPrinterLab.Migrations
{
    public partial class AdicionTablaSolicitudes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Solicitante",
                table: "Ordenes");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Ordenes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ImpresoraId",
                table: "Ordenes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumeroSolicitud",
                table: "Ordenes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Solicitante = table.Column<string>(type: "varchar(50)", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_NumeroSolicitud",
                table: "Ordenes",
                column: "NumeroSolicitud");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Solicitudes_NumeroSolicitud",
                table: "Ordenes",
                column: "NumeroSolicitud",
                principalTable: "Solicitudes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Solicitudes_NumeroSolicitud",
                table: "Ordenes");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_NumeroSolicitud",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "NumeroSolicitud",
                table: "Ordenes");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Ordenes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ImpresoraId",
                table: "Ordenes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Solicitante",
                table: "Ordenes",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
