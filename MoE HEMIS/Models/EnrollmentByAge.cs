using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class EnrollmentByAge
{
        public int EnrollmentByAgeId { get; set; }

        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }
        

        public int Males { get; set; }
        public int Females { get; set; }

        public AgeRange AgeRange { get; set; }
    }


}
