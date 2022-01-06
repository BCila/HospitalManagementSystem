using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneOtomasyon.Entities
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

    }
}
