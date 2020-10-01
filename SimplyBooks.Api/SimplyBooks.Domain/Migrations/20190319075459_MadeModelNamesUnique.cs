using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplyBooks.Domain.Migrations
{
    public partial class MadeModelNamesUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Book_Title",
                table: "Book",
                column: "Title");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Genre_Name",
                table: "Genre",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Author_Name",
                table: "Author",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Nationality_Name",
                table: "Nationality",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Book_Title",
                table: "Book");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Genre_Name",
                table: "Genre");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Author_Name",
                table: "Author");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Nationality_Name",
                table: "Nationality");
        }
    }
}