using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShopQuery.Migrations
{
    public partial class AddComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCommentQueries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    AdminId = table.Column<long>(type: "bigint", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductQueryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCommentQueries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCommentQueries_ProductQueries_ProductQueryId",
                        column: x => x.ProductQueryId,
                        principalTable: "ProductQueries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReplayCommentQueries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CommentId = table.Column<long>(type: "bigint", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    AdminId = table.Column<long>(type: "bigint", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReplayCommentQueries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReplayCommentQueries_ProductCommentQueries_CommentId",
                        column: x => x.CommentId,
                        principalTable: "ProductCommentQueries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCommentQueries_ProductQueryId",
                table: "ProductCommentQueries",
                column: "ProductQueryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReplayCommentQueries_CommentId",
                table: "ProductReplayCommentQueries",
                column: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductReplayCommentQueries");

            migrationBuilder.DropTable(
                name: "ProductCommentQueries");
        }
    }
}
