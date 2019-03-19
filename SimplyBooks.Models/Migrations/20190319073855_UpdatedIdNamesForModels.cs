using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplyBooks.Models.Migrations
{
    public partial class UpdatedIdNamesForModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Nationality",
                newName: "NationalityId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genre",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Book",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Author",
                newName: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NationalityId",
                table: "Nationality",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Genre",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Book",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Author",
                newName: "Id");
        }
    }
}
