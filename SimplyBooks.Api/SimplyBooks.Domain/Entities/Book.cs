using System;
using System.ComponentModel.DataAnnotations;

namespace SimplyBooks.Domain
{
    public class Book
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public Author Author { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public DateTime DateRead { get; set; }

        public DateTime YearPublished { get; set; }
    }
}
