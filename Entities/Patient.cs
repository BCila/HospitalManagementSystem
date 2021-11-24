using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyon.Entities
{
    public class Patient
    {
        public Patient()
        {
            Status = true;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string ContactNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public DateTime AddmissionDate { get; set; }
        public bool Status { get; set; }

        //Doktor ilişkisi
        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

    }
}
