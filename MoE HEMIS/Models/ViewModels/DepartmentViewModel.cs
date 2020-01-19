using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models.ViewModels
{
    public class DepartmentViewModel
    {
        public Department Department { get; set; }
        public IEnumerable<AcademicStaff> AcademicStaffs { get; set; }
    }
}
