using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimplyBooks.Models
{
    public class Nationality
    {
        [Required]
        public int NationalityId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
