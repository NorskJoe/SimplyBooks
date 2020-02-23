using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplyBooks.Models.Migrations
{
    public partial class UpdateYearReadToDateRead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Table/column changes
            migrationBuilder.DropColumn(
                name: "YearRead",
                table: "Book");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRead",
                table: "Book",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            // Data migration changes - applied to top 10 recent books only
            migrationBuilder.Sql(@"
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, DateRead, YearPublished) VALUES ('The Eye of the World', 3, 14, 8, CONVERT(datetime, '2018', 103), CONVERT(datetime, '1990', 103))
                UPDATE Book SET DateRead = CAST('2019-01-15' AS DATETIME) WHERE BookId = 63
                UPDATE Book SET DateRead = CAST('2018-10-05' AS DATETIME) WHERE BookId = 28
                UPDATE Book SET DateRead = CAST('2018-09-19' AS DATETIME) WHERE BookId = 73
                UPDATE Book SET DateRead = CAST('2018-07-22' AS DATETIME) WHERE BookId = 60
                UPDATE Book SET DateRead = CAST('2018-06-10' AS DATETIME) WHERE BookId = 64
                UPDATE Book SET DateRead = CAST('2018-04-19' AS DATETIME) WHERE Title = 'The Eye of the World'
                UPDATE Book SET DateRead = CAST('2018-02-28' AS DATETIME) WHERE BookId = 45
                UPDATE Book SET DateRead = CAST('2018-02-08' AS DATETIME) WHERE BookId = 24
                UPDATE Book SET DateRead = CAST('2018-01-24' AS DATETIME) WHERE BookId = 66
                UPDATE Book SET DateRead = CAST('2017-10-24' AS DATETIME) WHERE BookId = 44  
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRead",
                table: "Book");

            migrationBuilder.AddColumn<DateTime>(
                name: "YearRead",
                table: "Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
