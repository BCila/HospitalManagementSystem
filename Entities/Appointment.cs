using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyon.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("DoctorId")]
        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        //Specializition Relationship
        [ForeignKey("Specialization")]
        public int? SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }


    }
}
