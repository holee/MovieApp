using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Register
    {
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name ="Is Active")]
        public bool IsActive { get; set; }

    }
}
