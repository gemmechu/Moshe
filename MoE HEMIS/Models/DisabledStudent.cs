using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class DisabledStudent : Student
    {
        public int DisabledStudentId { get; set; }
        public Disability Disability { get; set; }
    }

    public enum Disability
    {
        VISUALLY_IMPAIRED,
        HEARING_IMPAIRED,
        PHYSICALLY_CHALLENGED,
        OTHERS
    }
}
