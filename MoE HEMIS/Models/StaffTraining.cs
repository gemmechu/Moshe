using System.ComponentModel.DataAnnotations;

namespace MoE_HEMIS.Models
{
    public class StaffTraining
    {
        public int StaffTrainingId { get; set; }
        public virtual College College { get; set; }
        public int CollegeId { get; set; }
        public virtual Department Department { get; set; }
        public int? DepartmentId { get; set; }

        public int Males { get; set; }
        public int Females { get; set; }

        [EnumDataType(typeof(TrainingStatus))]
        public TrainingStatus Status { get; set; }
        [EnumDataType(typeof(TrainingType))]
        public TrainingType Type { get; set; }
    }

}
