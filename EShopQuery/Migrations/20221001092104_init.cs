using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShopQuery.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerDiscountQueries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountPercent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDiscountQueries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryQueries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    CurrentCount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryQueries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryQueries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryQueries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SliderQueries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    PicturePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PictureTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Heading = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BodyText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ButtonText = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RedirectUrl = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderQueries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryOperationQueries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    OperatorId = table.Column<long>(type: "bigint", nullable: false),
                    CurrentCount = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    InventoryOperationQueryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryOperationQueries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryOperationQueries_InventoryOperationQueries_InventoryOperationQueryId",
                        column: x => x.InventoryOperationQueryId,
                        principalTable: "InventoryOperationQueries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryOperationQueries_InventoryQueries_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "InventoryQueries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductQueries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ProductCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerDiscountId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductQueries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductQueries_CustomerDiscountQueries_CustomerDiscountId",
                        column: x => x.CustomerDiscountId,
                        principalTable: "CustomerDiscountQueries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductQueries_InventoryQueries_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "InventoryQueries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductQueries_ProductCategoryQueries_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategoryQueries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPictureQueries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PictureTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPictureQueries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPictureQueries_ProductQueries_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductQueries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOperationQueries_InventoryId",
                table: "InventoryOperationQueries",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryOperationQueries_InventoryOperationQueryId",
                table: "InventoryOperationQueries",
                column: "InventoryOperationQueryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictureQueries_ProductId",
                table: "ProductPictureQueries",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductQueries_CustomerDiscountId",
                table: "ProductQueries",
                column: "CustomerDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductQueries_InventoryId",
                table: "ProductQueries",
                column: "InventoryId",
                unique: true,
                filter: "[InventoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductQueries_ProductCategoryId",
                table: "ProductQueries",
                column: "ProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryOperationQueries");

            migrationBuilder.DropTable(
                name: "ProductPictureQueries");

            migrationBuilder.DropTable(
                name: "SliderQueries");

            migrationBuilder.DropTable(
                name: "ProductQueries");

            migrationBuilder.DropTable(
                name: "CustomerDiscountQueries");

            migrationBuilder.DropTable(
                name: "InventoryQueries");

            migrationBuilder.DropTable(
                name: "ProductCategoryQueries");
        }
    }
}
