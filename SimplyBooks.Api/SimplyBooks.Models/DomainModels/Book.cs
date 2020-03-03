using System;
using System.ComponentModel.DataAnnotations;

namespace SimplyBooks.Models
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

        public double Rating { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources.General), Name ="YearRead")]
        public DateTime DateRead { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources.General), Name = "YearPublished")]
        public DateTime YearPublished { get; set; }
    }
}
