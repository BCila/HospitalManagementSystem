using Microsoft.AspNetCore.Identity;

namespace HastaneOtomasyon.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string TcNo { get; set; }
    }
}
