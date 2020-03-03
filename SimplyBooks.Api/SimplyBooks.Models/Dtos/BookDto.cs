using System;

namespace SimplyBooks.Models.Dtos
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }
        public DateTime YearRead { get; set; }
        public DateTime YearPublished { get; set; }
    }
}
