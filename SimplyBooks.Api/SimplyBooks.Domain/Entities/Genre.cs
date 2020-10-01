using System.ComponentModel.DataAnnotations;

namespace SimplyBooks.Domain
{
    public class Genre
    {
        [Required]
        public int GenreId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
