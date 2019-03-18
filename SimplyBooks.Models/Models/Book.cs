using System;
using System.Collections.Generic;
using System.Text;

namespace SimplyBooks.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }
        public double Rating { get; set; }
        public DateTime YearRead { get; set; }
        public DateTime YearPublished { get; set; }
    }
}
