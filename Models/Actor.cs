using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Actor
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Address { get; set; } 
    }
}
