using HastaneOtomasyon.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace HastaneOtomasyon.Context
{
    public class HospitalDbContext:DbContext
    {
        public HospitalDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

    }
}
