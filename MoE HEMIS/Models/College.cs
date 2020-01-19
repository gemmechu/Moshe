using System.Collections.Generic;

namespace MoE_HEMIS.Models
{
    public class College
    {
        public int CollegeId { get; set; }
        public Institution Institution { get; set; }
        public int? InstitutionId { get; set; }

        public Band Band { get; set; }
        public int BandId { get; set; }

        public string Name { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual List<Department> Departments { get; set; }
        public virtual List<CostSharingReport> CostSharingReports { get; set; }

        #region   Rollback to previous
        
        //public ICollection<TechnicalStaff> TechnicalStaffs { get; set; }
        //public ICollection<TeachingStaffByLevel> TeachingStaffByLevels { get; set; }
        //public virtual ICollection<AcademicStaffByRank> AcademicStaffByRanks { get; set; }
        //public ICollection<ExpatriateByRank> ExpatriateByRanks { get; set; }

        //public ICollection<SpecialNeedEnrollment> SpecialNeedEnrollments { get; set; }
        //public ICollection<ForeignerStudent> ForeignerStudents { get; set; }
        #endregion

        #region Unchanged
        //public ICollection<Expatriate> Expatriates { get; set; }
        public ICollection<StaffProgram> StaffPrograms { get; set; }
        public ICollection<StaffTraining> StaffTrainings { get; set; }

        //added

        public virtual ICollection<BuildingData> BuildingDatas { get; set; }
        //public ICollection<AdministrativeAndSupportiveStaff> AdministrativeAndSupportiveStaffs { get; set; }
        public ICollection<AcademicStaff> AcademicStaffs { get; set; }
        public ICollection<AdministrativeStaff> AdministrativeStaffs { get; set; }
        public ICollection<Budget> Budgets { get; set; }
        public ICollection<InternalRevenue> InternalRevenues { get; set; }
        public ICollection<Investment> Investments { get; set; }
        //removed

        //public virtual ICollection<StudentAttrition> StudentAttritions { get; set; }
        //public ICollection<CompletionRate> CompletionRates { get; set; }
        //public ICollection<Enrollment> Enrollments { get; set; }
        //public ICollection<Graduate> Graduates { get; set; }
        //public ICollection<Internship> Internships { get; set; }
        //public ICollection<NewEnrollment> NewEnrollments { get; set; }
        //public ICollection<ProspectiveGraduate> ProspectiveGraduates { get; set; }
        //public ICollection<ResearchPaper> ResearchPapers { get; set; }
        //public ICollection<AcademicStaffUpgrading> AcademicStaffUpgradings { get; set; }
        //public ICollection<AcademicStaffStudyLeave> AcademicStaffStudyLeaves { get; set; }

        #endregion
    }
}
