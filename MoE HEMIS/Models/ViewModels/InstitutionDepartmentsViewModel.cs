using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models.ViewModels
{
    public class InstitutionDepartmentsViewModel
    {
        public Institution Institution { get; set; }
        public List<ApplicationUser> ApplicationUsers { get; set; }
    }
}
