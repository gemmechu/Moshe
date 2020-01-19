using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class SupportiveStaff : Staff
{
        public int SupportiveStaffId { get; set; }
        public virtual College College { get; set; }
        public int? collegeId { get; set; }
        [EnumDataType(typeof(SupportiveStaffLevel))] 
        public new SupportiveStaffLevel AcademicLevel { get; set; }
    }
    public enum SupportiveStaffLevel
    {
        DIPLOMA,
        BACHELORS,
        M_D_D_V_M,
        MASTERS,
        PHD,
        GRADE10ANDGREATER,
        GRADE11,
        GRADE12,
        TENP1,
        TENP2,
        TENP3,
        LEVEL_I,
        LEVEL_II,
        LEVEL_III,
        LEVEL_IV,
        LEVEL_V


    }
}
