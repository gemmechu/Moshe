namespace MoE_HEMIS.Models
{
    public class NewEnrollment
    {
        public int NewEnrollmentId { get; set; }


        public int Males { get; set; }
        public int Femals { get; set; }

        public StudyYear Year { get; set; } = StudyYear.I;
        public StudyProgram Program { get; set; }
        public StudyLevel Level { get; set; }

        public virtual Department Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}