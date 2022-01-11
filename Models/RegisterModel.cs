using System.ComponentModel.DataAnnotations;

namespace HastaneOtomasyon.Models
{
    public class RegisterModel
    {
        [Required]
        [MinLength(11, ErrorMessage = "Tc Kimlik No 11 hane olmalıdır")]
        [MaxLength(11, ErrorMessage = "Tc Kimlik No 11 hane olmalıdır")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password Zorunlu Bir Alandır.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set;}
        public string Email { get; set; }

    }
}
