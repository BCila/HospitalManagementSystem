using HastaneOtomasyon.Context;
using HastaneOtomasyon.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneOtomasyon.Controllers
{
    [Authorize]
    public class DoctorController:Controller
    {

        private readonly HospitalDbContext _context;
        public DoctorController(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Doctor>>> Index()
        {
            var doctorList = await _context.Doctors
                .Include(x => x.Specialization)
                .Where(x=>x.Status == true)
                .ToListAsync();

            return View(doctorList);
        }
        [HttpGet]
        public async Task<IActionResult> CreateDoctor()
        {
            List<SelectListItem> valueSpecialization = (from x in await
                                                        _context.Specializations.ToListAsync()
                                                         select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.Id.ToString()
                                                        }).ToList();
            
            ViewBag.specilizationSelectList = valueSpecialization;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateDoctor(Doctor doctor)
        {
            await _context.Doctors.AddAsync(new Doctor
            {
                Name = doctor.Name,
                Surname = doctor.Surname,
                Address = doctor.Address,
                Gender = doctor.Gender,
                SpecializationId = doctor.SpecializationId
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> DeleteDoctor(int id) 
        {
            var doctorId = await _context.Doctors.FirstOrDefaultAsync(x=>x.Id == id);
            if(doctorId is null)
            {
                return NotFound();
            } 
            doctorId.Status = false;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> UpdateDoctor(int id) 
        {
            List<SelectListItem> valueSpecialization = (from x in await
                                            _context.Specializations.ToListAsync()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.Id.ToString()
                                                        }).ToList();

            ViewBag.specilizationSelectList = valueSpecialization;

            var doctorId = await _context.Doctors.FindAsync(id);
            return View(doctorId);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateDoctor(int id,Doctor doctor)
        {
            var doctorId = await _context.Doctors.FindAsync(id);
            if (doctorId == null)
            {
                return NotFound();
            }

            doctorId.Name = doctor.Name;
            doctorId.Surname = doctor.Surname;
            doctorId.Gender = doctor.Gender;
            doctorId.Address = doctor.Address;
            doctorId.SpecializationId = doctor.SpecializationId;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        public async Task<ActionResult<Doctor>> SearchDoctor(string searchValue)
        {
            var search =await _context.Doctors.Include(x=>x.Specialization).Where(x => x.Status == true).ToListAsync();


            if(!string.IsNullOrEmpty(searchValue))
            {
                search =search.Where(x => x.Name.ToLower().Contains(searchValue.ToLower().Trim())
                || x.Surname.ToLower().Contains(searchValue.ToLower())
                || x.Gender.ToLower().Contains(searchValue.ToLower().Trim())
                || x.Specialization.Name.ToLower().Contains(searchValue.ToLower().Trim())
                ).ToList();
            }
            
            return View("Index",search);
        }
    }
}
