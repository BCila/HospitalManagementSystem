using HastaneOtomasyon.Context;
using Microsoft.AspNetCore.Mvc;

namespace HastaneOtomasyon.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly HospitalDbContext _context;
        public AppointmentController(HospitalDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
