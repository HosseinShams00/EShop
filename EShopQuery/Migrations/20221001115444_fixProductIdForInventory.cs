using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShopQuery.Migrations
{
    public partial class fixProductIdForInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductQueries_InventoryQueries_InventoryId",
                table: "ProductQueries");

            migrationBuilder.DropIndex(
                name: "IX_ProductQueries_InventoryId",
                table: "ProductQueries");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "ProductQueries");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "InventoryQueries",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryQueries_ProductId",
                table: "InventoryQueries",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryQueries_ProductQueries_ProductId",
                table: "InventoryQueries",
                column: "ProductId",
                principalTable: "ProductQueries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryQueries_ProductQueries_ProductId",
                table: "InventoryQueries");

            migrationBuilder.DropIndex(
                name: "IX_InventoryQueries_ProductId",
                table: "InventoryQueries");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "InventoryQueries");

            migrationBuilder.AddColumn<long>(
                name: "InventoryId",
                table: "ProductQueries",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductQueries_InventoryId",
                table: "ProductQueries",
                column: "InventoryId",
                unique: true,
                filter: "[InventoryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductQueries_InventoryQueries_InventoryId",
                table: "ProductQueries",
                column: "InventoryId",
                principalTable: "InventoryQueries",
                principalColumn: "Id");
        }
    }
}
