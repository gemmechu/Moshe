using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class ForeignerStudent : Student
    {
        public int ForeignerStudentId { get; set; }
        public string Nationality { get; set; }
        public int YearsInEthiopia { get; set; }
    }
}
