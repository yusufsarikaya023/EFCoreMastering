using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMastering2Relationship.Migrations
{
    /// <inheritdoc />
    public partial class BookShadowForCategory2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Books",
                newName: "MainCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                newName: "IX_Books_MainCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_MainCategoryId",
                table: "Books",
                column: "MainCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_MainCategoryId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "MainCategoryId",
                table: "Books",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_MainCategoryId",
                table: "Books",
                newName: "IX_Books_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
