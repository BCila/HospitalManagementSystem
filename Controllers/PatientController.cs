using HastaneOtomasyon.Context;
using HastaneOtomasyon.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneOtomasyon.Controllers
{
    public class PatientController : Controller
    {

        private readonly HospitalDbContext _context;
        public PatientController(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Patient>>> Index()
        {
            var patientList = await _context.Patients.Where(x => x.Status == true).ToListAsync();

            return View(patientList);
        }

        [HttpGet]
        public IActionResult CreatePatient()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePatient(Patient patient)
        {
            await _context.Patients.AddAsync(new Patient
            {
                Name = patient.Name,
                Surname = patient.Surname,
                Gender = patient.Gender,
                Age = patient.Age,
                ContactNo = patient.ContactNo,
                DateOfBirth = patient.DateOfBirth,
                Height = patient.Height,
                Weight = patient.Weight,
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        
        }

        public async Task<ActionResult> DeletePatient(int id)
        {
            var patientId = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
            if (patientId == null)
            {
                return NotFound();
            }
            patientId.Status = false;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> UpdatePatient(int id)
        {
            var patientById = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
            return View(patientById);
        }

        [HttpPost]
        public async Task<ActionResult> UpdatePatient(int id,Patient patient)
        {
            var patientById = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
            if(patientById == null)
            {
                return NotFound();
            }
            patientById.Name = patient.Name;
            patientById.Surname = patient.Surname;
            patientById.Age = patient.Age;
            patientById.ContactNo = patient.ContactNo;
            patientById.DateOfBirth = patient.DateOfBirth;
            patientById.Height = patient.Height;
            patientById.Weight = patient.Weight;
            patientById.Gender = patient.Gender;
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult<Patient>> SearchPatient(string searchValue)
        {
            var search = await _context.Patients.Where(x => x.Status == true).ToListAsync();


            if (!string.IsNullOrEmpty(searchValue))
            {
                search = search.Where(
                    x => x.Name.ToLower().Contains(searchValue.ToLower().Trim())
                 || x.Surname.ToLower().Contains(searchValue.ToLower())
                 || x.Gender.ToLower().Contains(searchValue.ToLower().Trim())
                 || x.ContactNo.Contains(searchValue.ToLower().Trim())
                ).ToList();
            }

            return View("Index", search);
        }
    }
}
