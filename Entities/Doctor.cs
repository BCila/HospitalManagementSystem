using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneOtomasyon.Entities
{
    public class Doctor
    {
        public Doctor()
        {
            Status = true;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }

        //Patient Relationship
        public virtual ICollection<Patient> Patients { get; set; }

        //Specializition Relationship
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
    }
}
