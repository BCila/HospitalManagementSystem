using HastaneOtomasyon.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace HastaneOtomasyon.Context
{
    public class HospitalDbContext: IdentityDbContext<ApplicationUser>
    {
        public HospitalDbContext([NotNullAttribute] DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Appointment> Appointments{ get; set; }
        public DbSet<ApplicationUser> AplicationUsers{ get; set; }

    }
}
