using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplyBooks.Domain.Migrations
{
    public partial class RemoveIncorrectInsertIntoGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Genre WHERE Id = 5");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
