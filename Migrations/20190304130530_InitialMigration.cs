using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFModels.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => new { x.FirstName, x.LastName });
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Isbn = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    price = table.Column<float>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PublishedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Isbn);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    BookAuthorsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookIsbn = table.Column<int>(nullable: false),
                    AuthorFirstName = table.Column<string>(nullable: true),
                    AuthorLastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.BookAuthorsId);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Book_BookIsbn",
                        column: x => x.BookIsbn,
                        principalTable: "Book",
                        principalColumn: "Isbn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Author_AuthorFirstName_AuthorLastName",
                        columns: x => new { x.AuthorFirstName, x.AuthorLastName },
                        principalTable: "Author",
                        principalColumns: new[] { "FirstName", "LastName" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceOffer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NewPrice = table.Column<float>(nullable: false),
                    PromotionText = table.Column<string>(nullable: true),
                    BookIsbn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceOffer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceOffer_Book_BookIsbn",
                        column: x => x.BookIsbn,
                        principalTable: "Book",
                        principalColumn: "Isbn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Votername = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    NumStars = table.Column<int>(nullable: false),
                    BookIsbn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Book_BookIsbn",
                        column: x => x.BookIsbn,
                        principalTable: "Book",
                        principalColumn: "Isbn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookIsbn",
                table: "BookAuthors",
                column: "BookIsbn");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorFirstName_AuthorLastName",
                table: "BookAuthors",
                columns: new[] { "AuthorFirstName", "AuthorLastName" });

            migrationBuilder.CreateIndex(
                name: "IX_PriceOffer_BookIsbn",
                table: "PriceOffer",
                column: "BookIsbn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_BookIsbn",
                table: "Review",
                column: "BookIsbn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "PriceOffer");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
