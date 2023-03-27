using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Genres
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Genre { get; set; } = string.Empty;

        [StringLength(250)]
        public string Description { get; set; } = string.Empty;
    }
}
