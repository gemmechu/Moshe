using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoE_HEMIS.Models;

namespace MoE_HEMIS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Investment> Investments { get; set;}
        public DbSet<InternalRevenue> InternalRevenues { get; set; }
        public DbSet<DisabledStudent> DisabledStudents { get; set; }
        public DbSet<ForeignerStudent> ForeignerStudents { get; set; }


        public DbSet<Department> Departments { get; set; }
        public DbSet<Instance> Instances { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<StudentAttrition> StudentAttritions { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Graduate> Graduates { get; set; }
        public DbSet<ProspectiveGraduate> ProspectiveGraduates { get; set; }
        public DbSet<College> College { get; set; }

        //
         
        public DbSet<AcademicStaff> AcademicStaffs { get; set; }
        public DbSet<AdministrativeStaff> AdministrativeStaffs { get; set; }
        public DbSet<SupportiveStaff> SupportiveStaffs { get; set; }
        public DbSet<TechnicalStaff> TechnicalStaffs { get; set; } 


        public DbSet<BuildingData> BuildingDatas { get; set; }
        public DbSet<CompletionRate> CompletionRates { get; set; }
        public DbSet<EmergingRegionEnrollment> EmergingRegionEnrollments { get; set; }
        public DbSet<EnrollmentByAge> EnrollmentByAges { get; set; }
        public DbSet<Internship> Internships { get; set; }
        public DbSet<NewEnrollment> NewEnrollments { get; set; }
        public DbSet<PastoralRegionEnrollment> PastoralRegionEnrollments { get; set; }
        public DbSet<ResearchPaper> ResearchPapers { get; set; }
        public DbSet<SpecialityEnrollment> SpecialityEnrollments { get; set; }
        public DbSet<StaffProgram> StaffPrograms { get; set; }
        public DbSet<StaffTraining> StaffTrainings { get; set; }
        public DbSet<ManagementData> ManagementData { get; set; }
        public DbSet<BudgetDescription> BudgetDescription { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<CostSharingReport> CostSharingReports { get; set; }
        public DbSet<CostSharingReportFile> CostSharingReportFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Institution>().HasIndex(e => e.Name);
            //builder.Entity<AcademicStaffStudyLeave>().HasIndex(e => new { e.CollegeId, e.DepartmentId, e.StudyLeaveReason, e.StudyLocation });
            //builder.Entity<AcademicStaffUpgrading>().HasIndex(e => new { e.CollegeId, e.DepartmentId, e.StudyLeaveReason, e.StudyLocation });
            //builder.Entity<AdministrativeAndSupportiveStaff>().HasIndex(e => new { e.InstitutionId, e.Level, e.Dedication});
            //builder.Entity<Band>().HasIndex(e =>  e.BandName);
            //builder.Entity<College>().HasIndex(e => e.Name);
            //builder.Entity<Department>().HasIndex(e => new { e.DepartmentNameId, e.CollegeId });
            //builder.Entity<DepartmentName>().HasIndex(e => e.DepartmentNameId);
            //builder.Entity<EmergingRegionEnrollment>().HasIndex(e => new { e.InstitutionId, e.Year, e.Program, e.Region});
            //builder.Entity<Enrollment>().HasIndex(e => new { e.CollegeId, e.DepartmentId, e.Year, e.Program, e.Level});
            //builder.Entity<EnrollmentByAge>().HasIndex(e => new { e.InstitutionId, e.AgeRange});
            //builder.Entity<Graduate>().HasIndex(e => new { e.CollegeId, e.DepartmentId, e.Program, e.Level});
            //builder.Entity<ManagementData>().HasIndex(e => new { e.InstitutionId, e.Level});
            //builder.Entity<NewEnrollment>().HasIndex(e => new { e.CollegeId, e.DepartmentId, e.Year, e.Program, e.Level});
            //builder.Entity<PastoralRegionEnrollment>().HasIndex(e => new { e.InstitutionId, e.Year, e.Program, e.Region });
            //builder.Entity<ProspectiveGraduate>().HasIndex(e => new {  e.CollegeId, e.Program, e.Level});
            //builder.Entity<ResearchPaper>().HasIndex(e => new { e.CollegeId, e.Status});
            //builder.Entity<StaffProgram>().HasIndex(e => new { e.CollegeId, e.DepartmentId, e.Status, e.Type });
            //builder.Entity<StaffTraining>().HasIndex(e => new { e.CollegeId, e.DepartmentId, e.Status, e.Type });
            //builder.Entity<StudentAttrition>().HasIndex(e => new { e.CollegeId, e.Case, e.Program, e.Level });

        }

        public DbSet<MoE_HEMIS.Models.EconomicalDisadvantagedEnrollment> EconomicalDisadvantagedEnrollment { get; set; }

        public DbSet<MoE_HEMIS.Models.RuralEnrollment> RuralEnrollment { get; set; }

        public DbSet<MoE_HEMIS.Models.EconomicalDisadvantagedGraduate> EconomicalDisadvantagedGraduate { get; set; }

        public DbSet<MoE_HEMIS.Models.RuralGraduate> RuralGraduate { get; set; }

        public DbSet<MoE_HEMIS.Models.SpecialNeedGraduate> SpecialNeedGraduate { get; set; }

        public DbSet<MoE_HEMIS.Models.CostSharingReport> CostSharingReport { get; set; }

        public DbSet<MoE_HEMIS.Models.StaffPublication> StaffPublication { get; set; }

        public DbSet<MoE_HEMIS.Models.UnjustifiableExpense> UnjustifiableExpense { get; set; }

        public DbSet<MoE_HEMIS.Models.PostGraduateResearchPublication> PostGraduateResearchPublication { get; set; }

        public DbSet<MoE_HEMIS.Models.IntakeCapacity> IntakeCapacity { get; set; }
        public DbSet<SpecialNeedAttrition> SpecialNeedAttrition { get; internal set; }
        public DbSet<RuralAttrition> RuralAttrition { get; internal set; }
        public DbSet<GraduatesTotalExitExaminationByEconomy> GraduatesTotalExitExaminationByEconomy { get; internal set; }
        public DbSet<GraduatesTotalExitExaminationByDisability> GraduatesTotalExitExaminationByDisability { get; internal set; }
        public DbSet<GraduatesTotalExitExamination> GraduatesTotalExitExamination { get; internal set; }
        public DbSet<Expatriate> Expatriates { get; internal set; }
        public DbSet<MoE_HEMIS.Models.EconomicalDisadvantagedAttrition> EconomicalDisadvantagedAttrition { get; set; }
        public DbSet<EmergingRegionAttrition> EmergingRegionAttritions { get; set; }






    }

}
