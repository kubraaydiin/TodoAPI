using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Model
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(5)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Department info is required")]
        public string Department { get; set; }
    }
}
