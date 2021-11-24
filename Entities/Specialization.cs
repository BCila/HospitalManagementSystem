using System.Collections.Generic;

namespace HastaneOtomasyon.Entities
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Doctor Relationship
        public ICollection<Doctor> Doctors { get; set; }
        
    }
}
