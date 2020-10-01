using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplyBooks.Domain.Migrations
{
    public partial class FixData_AuthorMismatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE Book SET AuthorId = 40 WHERE BookId = 61
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
