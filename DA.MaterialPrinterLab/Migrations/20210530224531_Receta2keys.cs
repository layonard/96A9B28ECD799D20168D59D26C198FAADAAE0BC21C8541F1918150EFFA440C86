using Microsoft.EntityFrameworkCore.Migrations;

namespace DA.MaterialPrinterLab.Migrations
{
    public partial class Receta2keys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Recetas",
                table: "Recetas");

            migrationBuilder.DropIndex(
                name: "IX_Recetas_ItemId",
                table: "Recetas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Recetas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recetas",
                table: "Recetas",
                columns: new[] { "ItemId", "InsumoId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Recetas",
                table: "Recetas");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Recetas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recetas",
                table: "Recetas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_ItemId",
                table: "Recetas",
                column: "ItemId");
        }
    }
}
