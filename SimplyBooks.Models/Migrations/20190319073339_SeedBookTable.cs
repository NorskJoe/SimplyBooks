﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplyBooks.Models.Migrations
{
    public partial class SeedBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('A Brief History of Time', 8, 26, 6.5, CONVERT(datetime, '2015', 103), CONVERT(datetime, '1988', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('A Clash of Kings', 3, 9, 8, CONVERT(datetime, '2012', 103), CONVERT(datetime, '1998', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('A Clockwork Orange', 16, 38, 8, CONVERT(datetime, '2017', 103), CONVERT(datetime, '1962', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('A Dance with Dragons', 3, 9, 8, CONVERT(datetime, '2012', 103), CONVERT(datetime, '2011', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('A Feast for Crows', 3, 9, 7, CONVERT(datetime, '2012', 103), CONVERT(datetime, '2005', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('A Game of Thrones', 3, 9, 8, CONVERT(datetime, '2012', 103), CONVERT(datetime, '1996', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('A Little Life', 18, 42, 7.5, CONVERT(datetime, '2016', 103), CONVERT(datetime, '2015', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('A Scanner Darkly', 2, 5, 7, CONVERT(datetime, '2012', 103), CONVERT(datetime, '1977', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('A Short History of Nearly Everything', 8, 25, 8, CONVERT(datetime, '2015', 103), CONVERT(datetime, '2003', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('A Storm of Swords', 3, 9, 9, CONVERT(datetime, '2012', 103), CONVERT(datetime, '2000', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('All Hell Let Loose', 11, 32, 6.5, CONVERT(datetime, '2015', 103), CONVERT(datetime, '2011', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Animal Farm', 12, 33, 8, CONVERT(datetime, '2015', 103), CONVERT(datetime, '1945', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Batman: A Death in the Family', 7, 19, 6.5, CONVERT(datetime, '2013', 103), CONVERT(datetime, '1988', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Batman: Arkham Asylum', 7, 5, 7, CONVERT(datetime, '2013', 103), CONVERT(datetime, '1989', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Batman: Dark Victory', 7, 18, 7, CONVERT(datetime, '2013', 103), CONVERT(datetime, '1999', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Batman: Hush', 7, 18, 7.5, CONVERT(datetime, '2013', 103), CONVERT(datetime, '2002', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Batman: Knightfall (part 1)', 7, 21, 6.5, CONVERT(datetime, '2013', 103), CONVERT(datetime, '1993', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Batman: Knightfall (part 2)', 7, 22, 7, CONVERT(datetime, '2015', 103), CONVERT(datetime, '1993', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Batman: Knightfall (part 3)', 7, 22, 5, CONVERT(datetime, '2017', 103), CONVERT(datetime, '1993', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Batman: The Killing Joke', 7, 4, 7.5, CONVERT(datetime, '2013', 103), CONVERT(datetime, '2016', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Batman: The Long Halloween', 7, 18, 8, CONVERT(datetime, '2013', 103), CONVERT(datetime, '1996', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Batman: Year One', 7, 17, 7, CONVERT(datetime, '2013', 103), CONVERT(datetime, '1988', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Blood Meridian', 18, 43, 7, CONVERT(datetime, '2017', 103), CONVERT(datetime, '1985', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Brave New World', 16, 39, 8, CONVERT(datetime, '2018', 103), CONVERT(datetime, '1932', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Chapter House Dune ', 2, 4, 7, CONVERT(datetime, '2012', 103), CONVERT(datetime, '1985', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Congo', 2, 7, 7.5, CONVERT(datetime, '2014', 103), CONVERT(datetime, '1980', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Do Androids Dream of Electric Sheep?', 2, 5, 8, CONVERT(datetime, '2012', 103), CONVERT(datetime, '1968', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Electric Dreams: Volume 1', 2, 5, 8, CONVERT(datetime, '2018', 103), CONVERT(datetime, '2017', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Everything is Illuminated', 9, 28, 5, CONVERT(datetime, '2014', 103), CONVERT(datetime, '2002', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Fahrenheit 451', 16, 37, 7.5, CONVERT(datetime, '2016', 103), CONVERT(datetime, '1953', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Fever Pitch', 13, 34, 6.5, CONVERT(datetime, '2015', 103), CONVERT(datetime, '1992', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Gormenghast', 10, 31, 7, CONVERT(datetime, '2014', 103), CONVERT(datetime, '1950', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('H is for Hawk', 14, 35, 7, CONVERT(datetime, '2015', 103), CONVERT(datetime, '2014', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Heart of Darkness', 15, 36, 6.5, CONVERT(datetime, '2015', 103), CONVERT(datetime, '1899', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Heretics of Dune', 2, 4, 6, CONVERT(datetime, '2012', 103), CONVERT(datetime, '1984', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('I Am The Secret Footballer', 1, 2, 6, CONVERT(datetime, '2012', 103), CONVERT(datetime, '2012', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Jurassic Park', 2, 7, 8, CONVERT(datetime, '2013', 103), CONVERT(datetime, '1990', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Life of Pi', 9, 29, 8, CONVERT(datetime, '2015', 103), CONVERT(datetime, '2001', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Lord of the Flies', 9, 30, 8, CONVERT(datetime, '2016', 103), CONVERT(datetime, '1954', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('My Autobiography', 1, 3, 7, CONVERT(datetime, '2013', 103), CONVERT(datetime, '2013', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Nineteen Eighty-Four', 16, 33, 8.5, CONVERT(datetime, '2016', 103), CONVERT(datetime, '1949', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Pillars of the Earth', 4, 15, 9, CONVERT(datetime, '2012', 103), CONVERT(datetime, '1989', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Quiet', 8, 24, 6, CONVERT(datetime, '2015', 103), CONVERT(datetime, '2012', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Red or Dead', 17, 41, 6.5, CONVERT(datetime, '2017', 103), CONVERT(datetime, '2013', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Red Seas Under Red Skies', 3, 13, 7, CONVERT(datetime, '2018', 103), CONVERT(datetime, '2007', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Sapiens', 8, 27, 8, CONVERT(datetime, '2016', 103), CONVERT(datetime, '2011', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Scar Tissue', 1, 1, 7, CONVERT(datetime, '2012', 103), CONVERT(datetime, '2004', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Slaughterhouse 5', 2, 8, 7, CONVERT(datetime, '2013', 103), CONVERT(datetime, '1969', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Andromeda Strain', 2, 7, 7, CONVERT(datetime, '2016', 103), CONVERT(datetime, '1971', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Botany of Desire', 8, 23, 6, CONVERT(datetime, '2013', 103), CONVERT(datetime, '2001', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Cat''s Cradle', 2, 8, 6, CONVERT(datetime, '2016', 103), CONVERT(datetime, '1963', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Dark Tower: Song of Susannah', 3, 11, 8, CONVERT(datetime, '2016', 103), CONVERT(datetime, '2004', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Dark Tower: The Dark Tower', 3, 11, 7, CONVERT(datetime, '2016', 103), CONVERT(datetime, '2004', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Dark Tower: The Drawing of the Three', 3, 11, 8.5, CONVERT(datetime, '2014', 103), CONVERT(datetime, '1987', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Dark Tower: The Gunslinger', 3, 11, 7.5, CONVERT(datetime, '2014', 103), CONVERT(datetime, '1982', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Dark Tower: The Waste Lands', 3, 11, 8, CONVERT(datetime, '2014', 103), CONVERT(datetime, '1991', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Dark Tower: Wizard and Glass', 3, 11, 8, CONVERT(datetime, '2015', 103), CONVERT(datetime, '1997', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Dark Tower: Wolves of the Calla', 3, 11, 7, CONVERT(datetime, '2016', 103), CONVERT(datetime, '2003', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Day of the Triffids', 2, 6, 8, CONVERT(datetime, '2013', 103), CONVERT(datetime, '1951', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Dragon Reborn', 3, 14, 7.5, CONVERT(datetime, '2018', 103), CONVERT(datetime, '1991', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Enigma', 17, 38, 6, CONVERT(datetime, '2016', 103), CONVERT(datetime, '1983', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Fellowship of the Ring', 3, 10, 8.5, CONVERT(datetime, '2013', 103), CONVERT(datetime, '1954', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Fires of Heaven', 3, 14, 7.5, CONVERT(datetime, '2019', 103), CONVERT(datetime, '1993', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Great Hunt', 3, 14, 8, CONVERT(datetime, '2018', 103), CONVERT(datetime, '1990', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Hobbit', 3, 10, 8, CONVERT(datetime, '2013', 103), CONVERT(datetime, '1937', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Lies of Locke Lamora', 3, 13, 8, CONVERT(datetime, '2017', 103), CONVERT(datetime, '2006', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Lost World', 2, 7, 7, CONVERT(datetime, '2013', 103), CONVERT(datetime, '1995', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Man in the High Castle', 2, 5, 7.5, CONVERT(datetime, '2015', 103), CONVERT(datetime, '1962', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Midwich Cuckoos', 2, 6, 8, CONVERT(datetime, '2017', 103), CONVERT(datetime, '1957', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Name of the Wind', 3, 12, 8.5, CONVERT(datetime, '2014', 103), CONVERT(datetime, '2007', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Psychopath Test', 19, 45, 7.5, CONVERT(datetime, '2017', 103), CONVERT(datetime, '2011', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Return of the King', 3, 10, 8.5, CONVERT(datetime, '2013', 103), CONVERT(datetime, '1955', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Shadow Rising', 3, 14, 8, CONVERT(datetime, '2018', 103), CONVERT(datetime, '1992', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Two Towers', 3, 10, 9, CONVERT(datetime, '2013', 103), CONVERT(datetime, '1954', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Waves', 18, 44, 6, CONVERT(datetime, '2017', 103), CONVERT(datetime, '1931', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('The Wise Mans Fear', 3, 12, 7.5, CONVERT(datetime, '2015', 103), CONVERT(datetime, '2011', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Titus Groan', 10, 31, 6.5, CONVERT(datetime, '2014', 103), CONVERT(datetime, '1946', 103))
                INSERT INTO Book(Title, GenreId, AuthorId, Rating, YearRead, YearPublished) VALUES ('Watchmen', 6, 4, 9, CONVERT(datetime, '2013', 103), CONVERT(datetime, '2008', 103))
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Book");
        }
    }
}
