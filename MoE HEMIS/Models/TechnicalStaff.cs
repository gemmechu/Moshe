using System.ComponentModel.DataAnnotations;

namespace MoE_HEMIS.Models
{
    public class TechnicalStaff : Staff
{
        public int TechnicalStaffId { get; set; }
        public virtual Department Department { get; set; }
        public int? departmentId { get; set; }
        [EnumDataType(typeof(TechnicalStaffRank))]
        public TechnicalStaffRank Rank { get; set; }
    }

 

    public enum TechnicalStaffRank
    {
        GRADUATE_ASSISTANT_I,
        GRADUATE_ASSISTANT_II,
        GRADUARE_LECTURER,
        LECTURER,
        ASSISTANT_PROFESSOR,
        ASSOCIATE_PROFFESSOR,
        OTHER
    }
}
