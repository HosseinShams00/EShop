using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Infrastructure.EFCore.Migrations
{
    public partial class AddSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PicturePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PictureTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Heading = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BodyText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ButtonText = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RedirectUrl = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");
        }
    }
}
