using System.ComponentModel.DataAnnotations;

namespace SimplyBooks.Domain
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
