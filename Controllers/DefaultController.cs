using HastaneOtomasyon.Context;
using HastaneOtomasyon.Entities;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult SpecializationCreate(Specialization specialization)
        {
            _context.Specializations.Add(new Specialization 
            {
                Name = specialization.Name            
            
            });
            _context.SaveChanges();

            return View("Index");
        }
        public async Task<IActionResult> SpecializationDelete(int id)
        {
            var deleted =await _context.Specializations.FindAsync(id);
            if(deleted is null)
            {
                return NotFound();
            }
             _context.Specializations.Remove(deleted);

            return NoContent();
        }

    }
}
