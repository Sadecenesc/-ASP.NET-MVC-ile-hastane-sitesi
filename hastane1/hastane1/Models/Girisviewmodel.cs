using System.ComponentModel.DataAnnotations;

namespace hastane1.Models
{
    public class Girisviewmodel
    {
        [Required(ErrorMessage = "Username is required.")]

        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; }
    }
}