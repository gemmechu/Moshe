using System.Collections.Generic;

namespace MoE_HEMIS.Models
{
    public class Institution
    {
        public int InstitutionId { get; set; }
        public string Name { get; set; }
        public string Abbrivation  { get; set; }

        public virtual Instance Instance  { get; set; }        
        public int InstanceId  { get; set; }

        public virtual List<College> Colleges { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string UserId { get; set; }

        

       
        public ICollection<ManagementData> MSanagementDatas { get; set; }

        //removed
        //public virtual ICollection<BuildingData> BuildingDatas { get; set; }
        //public ICollection<EmergingRegionEnrollment> EmergingRegionEnrollments { get; set; }
        //public ICollection<PastoralRegionEnrollment> PastoralRegionEnrollments { get; set; }
        //public ICollection<AdministrativeAndSupportiveStaff> AdministrativeAndSupportiveStaffs { get; set; }
        //public ICollection<EnrollmentByAge> EnrollmentByAges { get; set; }
    }
}
