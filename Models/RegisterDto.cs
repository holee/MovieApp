using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class RegisterDto 
    {
        [Key]
        public Guid ID { get; set; }


        [Remote("UserNameExist", "Account")]
        public string UserName { get; set; } = default!;
        [EmailAddress]
        [Required]
        [StringLength(100,MinimumLength =3)]
        public string Email { get; set; } = default!;
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please input password")]
        [MinLength(3, ErrorMessage = "password at least 3 characters.")]
        [MaxLength(100, ErrorMessage = "password not exceed 100 characters.")]
        public string Password { get; set; }=default!;

        [Display(Name ="First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

    }
}
