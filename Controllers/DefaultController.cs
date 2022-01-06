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
        public IActionResult DeleleSpecialization(int id)
        {
            var entity = _context.Specializations.FirstOrDefault(x => x.Id == id);
            _context.Specializations.Remove(entity);
            _context.SaveChanges();
            return RedirectToAction("GetSpecialization");
        }
        public IActionResult UpdateSpecialization(int id)
        {
            var entity = _context.Specializations.FirstOrDefault(x => x.Id == id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult UpdateSpecialization(int id,Specialization specialization)
        {
            var entity = _context.Specializations.FirstOrDefault(x => x.Id == id);

            entity.Id = specialization.Id;
            entity.Name = specialization.Name;
            
            _context.Update(entity);
            _context.SaveChanges();

            return RedirectToAction("GetSpecialization");
        }

    }
}
