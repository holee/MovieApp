using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models
{
    public enum Genre
    {
        Drama=1,
        Fantastic=2,
        Actions=3,
        Horors=4,
        Romantic=5,
        Advanture=6,
        Science=7
    }
    public class Movie
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public Genre?  Genre { get; set; }
        public string? Description { get; set; }
        public DateTime? ReleaseDate { get; set; }

    }
}
