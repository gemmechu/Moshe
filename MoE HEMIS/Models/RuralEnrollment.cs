namespace MoE_HEMIS.Models
{
    public  class RuralEnrollment
{       
        public int RuralEnrollmentId { get; set; }

        public int Males { get; set; }
        public int Femals { get; set; } 

        public StudyYear Year { get; set; }
        public StudyProgram Program { get; set; }
        public StudyLevel Level { get; set; }

        public virtual Department Department { get; set; }
        public int? DepartmentId { get; set; }
    }


}
