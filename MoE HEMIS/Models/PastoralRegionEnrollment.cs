namespace MoE_HEMIS.Models
{
    public class PastoralRegionEnrollment
    {

        public int PastoralRegionEnrollmentId { get; set; }

        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }

        public int Males { get; set; }
        public int Femals { get; set; }

        public StudyYear Year { get; set; }
        public StudyProgram Program { get; set; }
        public Region Region { get; set; }
        
    }

   

}
