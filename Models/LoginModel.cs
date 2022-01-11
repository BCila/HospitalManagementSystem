using System.ComponentModel.DataAnnotations;

namespace HastaneOtomasyon.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Password zorunlu alandır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MinLength(11, ErrorMessage = "Tc Kimlik No 11 hane olmalıdır")]
        [MaxLength(11,ErrorMessage ="Tc Kimlik No 11 hane olmalıdır")]
        public string UserName { get; set; }
    }
}
