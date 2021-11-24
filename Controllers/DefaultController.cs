using HastaneOtomasyon.Context;
using HastaneOtomasyon.Entities;
using HastaneOtomasyon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneOtomasyon.Controllers
{
    public class DefaultController : Controller
    {
        private readonly HospitalDbContext _context;
        public DefaultController(HospitalDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(); 
        }

        public async Task<ActionResult<IEnumerable<SpecializationVM>>> GetSpecialization()
        {
            var specListVM = new SpecializationVM {
                Specializations =await _context.Specializations.ToListAsync()
            };
            return View(specListVM);
        }
        public IActionResult SpecializationCreate()
        {

            return View();
        }
        [HttpPost]
        public IActionResult SpecializationCreate(SpecializationVM specializationVM)
        {
            _context.Specializations.Add(new Specialization 
            {
                Name = specializationVM.Specialization.Name            
            
            });
            _context.SaveChanges();

            return RedirectToAction("GetSpecialization");
        }

    }
}
