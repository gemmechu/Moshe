using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class StaffProgram
    {
        public int StaffProgramId { get; set; }
        public virtual College College { get; set; }
        public int CollegeId { get; set; }
        public virtual Department Department { get; set; }
        public int? DepartmentId { get; set; }

        public int Males { get; set; }
        public int Females { get; set; }

        [EnumDataType(typeof(ProgramType))]
        public ProgramType Type { get; set; }

        [EnumDataType(typeof(ProgramStatus))]
        public ProgramStatus Status { get; set; }
    }

}
