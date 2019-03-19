using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimplyBooks.Models
{
    public class Author
    {
        [Required]
        public int AuthorId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        public Nationality Nationality { get; set; }
    }
}
