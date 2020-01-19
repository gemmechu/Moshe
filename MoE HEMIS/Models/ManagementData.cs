namespace MoE_HEMIS.Models
{
    public class ManagementData
    {
        public int ManagementDataId { get; set; }
        public virtual Institution Institution { get; set; }
        public int? InstitutionId { get; set; }


        public ManagementLevel Level { get; set; }

        public int? NumberOfPositionRequired { get; set; }
        public int? CurrentlyAssigned { get; set; }
        public int? NumberOfFemales { get; set; }
    }

}
