using HastaneOtomasyon.Context;
using HastaneOtomasyon.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneOtomasyon.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly HospitalDbContext _context;
        public AppointmentController(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Appointment>>> Index()
        {
            var appointmentList = await _context.Patients.ToListAsync();

            return View(appointmentList);
        }


    }
}
