using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class AcademicStaff: Staff
{
        public int? AcademicStaffId { get; set; }
        public virtual Department Department { get; set; }
        public int? departmentId { get; set; }
        public string FieldOfStudy { get; set; }
        public int TeachingLoad { get; set; }
        public string TeachingLoadRemark { get; set; }
        [EnumDataType(typeof(AcademicStaffRank))]
        public AcademicStaffRank Rank { get; set; }
    }

    public enum AcademicStaffRank
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
