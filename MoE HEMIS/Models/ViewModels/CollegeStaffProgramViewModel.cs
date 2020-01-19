using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models.ViewModels
{
    public class CollegeStaffProgramViewModel
    {
        public College College { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
