using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreMastering4OneToOneRelationship.Migrations
{
    /// <inheritdoc />
    public partial class DeleteRestrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandImages_Brands_BrandId",
                table: "BrandImages");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandImages_Brands_BrandId",
                table: "BrandImages",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandImages_Brands_BrandId",
                table: "BrandImages");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandImages_Brands_BrandId",
                table: "BrandImages",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
