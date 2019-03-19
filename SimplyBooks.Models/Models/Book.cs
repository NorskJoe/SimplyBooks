using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

        [Display(ResourceType = typeof(Resources.General), Name ="YearRead")]
        public DateTime YearRead { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources.General), Name = "YearPublished")]
        public DateTime YearPublished { get; set; }
    }
}
