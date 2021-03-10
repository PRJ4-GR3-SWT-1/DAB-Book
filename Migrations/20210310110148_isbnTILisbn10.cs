using Microsoft.EntityFrameworkCore.Migrations;

namespace EFModels.Migrations
{
    public partial class isbnTILisbn10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Isbn",
                table: "Book",
                newName: "Isbn10");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Isbn10",
                table: "Book",
                newName: "Isbn");
        }
    }
}
