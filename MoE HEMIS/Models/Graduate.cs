namespace MoE_HEMIS.Models
{
    public class Graduate
{
        public int GraduateId { get; set; }


        public virtual Department Department { get; set; }
        public int? DepartmentId { get; set; }

        public int Males { get; set; }
        public int Females { get; set; }

        public StudyLevel Level { get; set; }
        public StudyProgram Program { get; set; }


    }
}
