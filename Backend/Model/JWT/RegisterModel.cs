using System.ComponentModel.DataAnnotations;

namespace Model.JWT
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Telephone  is required")]
        public string TelephoneNumber { get; set; }
    }
}
