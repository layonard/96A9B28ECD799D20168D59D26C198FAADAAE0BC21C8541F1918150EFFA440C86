using Microsoft.EntityFrameworkCore.Migrations;

namespace DA.MaterialPrinterLab.Migrations
{
    public partial class SinRelacionImpresoraItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Impresoras_ImpresoraId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Receta_Items_InsumoId",
                table: "Receta");

            migrationBuilder.DropIndex(
                name: "IX_Items_ImpresoraId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receta",
                table: "Receta");

            migrationBuilder.DropColumn(
                name: "ImpresoraId",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Receta",
                newName: "Recetas");

            migrationBuilder.RenameIndex(
                name: "IX_Receta_InsumoId",
                table: "Recetas",
                newName: "IX_Recetas_InsumoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recetas",
                table: "Recetas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recetas_Items_InsumoId",
                table: "Recetas",
                column: "InsumoId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recetas_Items_InsumoId",
                table: "Recetas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recetas",
                table: "Recetas");

            migrationBuilder.RenameTable(
                name: "Recetas",
                newName: "Receta");

            migrationBuilder.RenameIndex(
                name: "IX_Recetas_InsumoId",
                table: "Receta",
                newName: "IX_Receta_InsumoId");

            migrationBuilder.AddColumn<int>(
                name: "ImpresoraId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receta",
                table: "Receta",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ImpresoraId",
                table: "Items",
                column: "ImpresoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Impresoras_ImpresoraId",
                table: "Items",
                column: "ImpresoraId",
                principalTable: "Impresoras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receta_Items_InsumoId",
                table: "Receta",
                column: "InsumoId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
