namespace MoE_HEMIS.Models
{
    public class Internship
    {
        public int InternshipId { get; set; }
        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }

        public int NumberOfIndustriesLinked { get; set; }
        public string TrainingArea { get; set; }

        public int? NumberOfStudentsOnInternship_2ndYear { get; set; }
        public int? NumberOfStudentsOnInternship_3rdYear { get; set; }
        public int? NumberOfStudentsOnInternship_4thYear { get; set; }
        public int? NumberOfStudentsOnInternship_5thYear { get; set; }
        public int? NumberOfStudentsOnInternship_6thYear { get; set; }
        public int? NumberOfStudentsOnInternship_7thYear { get; set; }
    }
}
