using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class Expatriate
    {
        public int ExpatriateId { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public string FullName { get; set; }
        public string Country { get; set; }
        public string SubjectOfSpecialization { get; set; }
        public string Remark { get; set; }

        public Sex Sex { get; set; }
        public StudyLevel StudyLevel { get; set; }


        public string Passport { get; set; }
        public string Address { get; set; }
        public string StaffId { get; set; }
    } 
}
