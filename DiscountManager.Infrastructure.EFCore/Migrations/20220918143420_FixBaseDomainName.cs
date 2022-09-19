using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscountManager.Infrastructure.EFCore.Migrations
{
    public partial class FixBaseDomainName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "CustomerDiscounts",
                newName: "CreationTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "CustomerDiscounts",
                newName: "CreationDateTime");
        }
    }
}
