using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplyBooks.Models.Migrations
{
    public partial class SeedNationalityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            INSERT INTO Nationality(Name) VALUES('American')
            INSERT INTO Nationality(Name) VALUES('Welsh')
            INSERT INTO Nationality(Name) VALUES('Unknown')
            INSERT INTO Nationality(Name) VALUES('English')
            INSERT INTO Nationality(Name) VALUES('Scottish')
            INSERT INTO Nationality(Name) VALUES('Polish')
            INSERT INTO Nationality(Name) VALUES('Israeli')
            INSERT INTO Nationality(Name) VALUES('Canadian')
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM Nationality
            ");
        }
    }
}
