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
                AddmissionDate = patient.AddmissionDate,
                DoctorId = patient.DoctorId
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        
        }
    }
}
