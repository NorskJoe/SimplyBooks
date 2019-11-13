using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplyBooks.Models.Migrations
{
    public partial class SeedGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Genre(Name) VALUES('Autobiography')
                INSERT INTO Genre(Name) VALUES('Sci Fi')
                INSERT INTO Genre(Name) VALUES('Fantasy')
                INSERT INTO Genre(Name) VALUES('Historical Fiction')
                INSERT INTO Genre(Name) VALUES('Fantasy')
                INSERT INTO Genre(Name) VALUES('Graphic Novel')
                INSERT INTO Genre(Name) VALUES('Comic')
                INSERT INTO Genre(Name) VALUES('Popular Science')
                INSERT INTO Genre(Name) VALUES('Other')
                INSERT INTO Genre(Name) VALUES('Gothic')
                INSERT INTO Genre(Name) VALUES('History')
                INSERT INTO Genre(Name) VALUES('Satire')
                INSERT INTO Genre(Name) VALUES('Sport')
                INSERT INTO Genre(Name) VALUES('Memoir')
                INSERT INTO Genre(Name) VALUES('Novella')
                INSERT INTO Genre(Name) VALUES('Dystopian')
                INSERT INTO Genre(Name) VALUES('Biography')
                INSERT INTO Genre(Name) VALUES('Novel')
                INSERT INTO Genre(Name) VALUES('Social Science')
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Table Genre");
        }
    }
}
