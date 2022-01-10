using HastaneOtomasyon.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HastaneOtomasyon.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationPatient> _userManager;
        private readonly SignInManager<ApplicationPatient> _signInManager;
        public AccountController(UserManager<ApplicationPatient> userManager , SignInManager<ApplicationPatient> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Register()
        {

            return View();
        }

    }
}
