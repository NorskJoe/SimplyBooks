using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplyBooks.Models.Migrations
{
    public partial class SeedAuthorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Author(Name, NationalityId) VALUES('Anthony Keidis', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Anonymous', 3)
                INSERT INTO Author(Name, NationalityId) VALUES('Alex Ferguson', 5)
                INSERT INTO Author(Name, NationalityId) VALUES('Frank Herbert', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Philip K. Dick', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('John Wyndham', 4)
                INSERT INTO Author(Name, NationalityId) VALUES('Michael Crichton', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Kurt Vonnegut', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('George RR Martin', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('John RR Tolkien', 4)
                INSERT INTO Author(Name, NationalityId) VALUES('Stephen King', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Patrick Rothfuss', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Scott Lynch', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Robert Jordan', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Ken Follet', 2)
                INSERT INTO Author(Name, NationalityId) VALUES('Alan Moore', 4)
                INSERT INTO Author(Name, NationalityId) VALUES('Frank Miller', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Jeph Loeb', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Jim Starlin', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Grant Morrison', 5)
                INSERT INTO Author(Name, NationalityId) VALUES('Doug Moench', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Various', 3)
                INSERT INTO Author(Name, NationalityId) VALUES('Michael Pollan', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Susan Cain', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Bill Bryson', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Stephen Hawking', 4)
                INSERT INTO Author(Name, NationalityId) VALUES('Yuval Noah Harari', 7)
                INSERT INTO Author(Name, NationalityId) VALUES('Jonathan Safran Foer', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Yann Martel', 8)
                INSERT INTO Author(Name, NationalityId) VALUES('William Golding', 4)
                INSERT INTO Author(Name, NationalityId) VALUES('Mervyn Peake', 4)
                INSERT INTO Author(Name, NationalityId) VALUES('Max Hastings', 4)
                INSERT INTO Author(Name, NationalityId) VALUES('George Orwell', 4)
                INSERT INTO Author(Name, NationalityId) VALUES('Nick Hornby', 4)
                INSERT INTO Author(Name, NationalityId) VALUES('Helen MacDonald', 4)
                INSERT INTO Author(Name, NationalityId) VALUES('Joseph Conrad', 6)
                INSERT INTO Author(Name, NationalityId) VALUES('Ray Bradbury', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Anthony Burgess', 4)
                INSERT INTO Author(Name, NationalityId) VALUES('Aldous Huxley', 4)
                INSERT INTO Author(Name, NationalityId) VALUES('Andrew Hodges', 4)
                INSERT INTO Author(Name, NationalityId) VALUES('David Peace', 4)
                INSERT INTO Author(Name, NationalityId) VALUES('Hanya Yanagihara', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Cormac McCarthy', 1)
                INSERT INTO Author(Name, NationalityId) VALUES('Virginia Wolf', 4)
                INSERT INTO Author(Name, NationalityId) VALUES('Jon Ronson', 2)

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELET FROM Author");
        }
    }
}
