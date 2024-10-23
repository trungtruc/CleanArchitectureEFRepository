using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameProductLogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductLog",
                table: "ProductLog");

            migrationBuilder.RenameTable(
                name: "ProductLog",
                newName: "ProductLogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductLogs",
                table: "ProductLogs",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductLogs",
                table: "ProductLogs");

            migrationBuilder.RenameTable(
                name: "ProductLogs",
                newName: "ProductLog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductLog",
                table: "ProductLog",
                column: "Id");
        }
    }
}
