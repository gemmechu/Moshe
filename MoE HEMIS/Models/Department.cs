using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public  College College{ get; set; }
        public int? CollegeId { get; set; }
        public Institution Institution { get; set; }
        public int? InstitutionId { get; set; }

        public string Name { get; set; }

        //added
        public ICollection<EmergingRegionEnrollment> EmergingRegionEnrollments { get; set; }
        public ICollection<PastoralRegionEnrollment> PastoralRegionEnrollments { get; set; }
        public ICollection<EnrollmentByAge> EnrollmentByAges { get; set; }


        public virtual ICollection<StudentAttrition> StudentAttritions { get; set; }
        public ICollection<CompletionRate> CompletionRates { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Graduate> Graduates { get; set; }
        public ICollection<Internship> Internships { get; set; }
        public ICollection<NewEnrollment> NewEnrollments { get; set; }
        public ICollection<ProspectiveGraduate> ProspectiveGraduates { get; set; }
        public ICollection<ResearchPaper> ResearchPapers { get; set; }
        //public ICollection<AcademicStaffUpgrading> AcademicStaffUpgradings { get; set; }
        //public ICollection<AcademicStaffStudyLeave> AcademicStaffStudyLeaves { get; set; }

        public ICollection<SupportiveStaff> SupportiveStaffs { get; set; }
        public ICollection<TechnicalStaff> TechnicalStaffs { get; set; }
    }
}
