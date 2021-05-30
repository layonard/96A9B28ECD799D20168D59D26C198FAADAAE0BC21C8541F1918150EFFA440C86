using Microsoft.EntityFrameworkCore.Migrations;

namespace DA.MaterialPrinterLab.Migrations
{
    public partial class ModifNombreItemOrdenImpresion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Items_ItemFinalId",
                table: "Ordenes");

            migrationBuilder.RenameColumn(
                name: "ItemFinalId",
                table: "Ordenes",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Ordenes_ItemFinalId",
                table: "Ordenes",
                newName: "IX_Ordenes_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Items_ItemId",
                table: "Ordenes",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Items_ItemId",
                table: "Ordenes");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Ordenes",
                newName: "ItemFinalId");

            migrationBuilder.RenameIndex(
                name: "IX_Ordenes_ItemId",
                table: "Ordenes",
                newName: "IX_Ordenes_ItemFinalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Items_ItemFinalId",
                table: "Ordenes",
                column: "ItemFinalId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
