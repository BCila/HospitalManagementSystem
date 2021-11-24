using HastaneOtomasyon.Entities;
using System.Collections.Generic;

namespace HastaneOtomasyon.Models
{
    public class SpecializationVM
    {
        public ICollection<Specialization> Specializations { get; set; }
        public Specialization Specialization { get; set; }
    }
}
