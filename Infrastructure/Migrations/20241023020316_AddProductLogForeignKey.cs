using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProductLogForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductLogs_ProductId",
                table: "ProductLogs",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLogs_Products_ProductId",
                table: "ProductLogs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLogs_Products_ProductId",
                table: "ProductLogs");

            migrationBuilder.DropIndex(
                name: "IX_ProductLogs_ProductId",
                table: "ProductLogs");
        }
    }
}
