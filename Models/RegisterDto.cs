using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class RegisterDto 
    {
        [Key]
        public Guid ID { get; set; }
        public string UserName { get; set; } = default!;

        [EmailAddress]
        public string Email { get; set; } = default!;

        [DataType(DataType.Password)]
        public string Password { get; set; }=default!;

        [Display(Name ="First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

    }
}
