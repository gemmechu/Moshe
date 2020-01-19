using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class GraduatesTotalExitExaminationByDisability
    {
        public int GraduatesTotalExitExaminationByDisabilityId { get; set; }

        public Department Department { get; set; }
        public int? DepartmentId { get; set; }

        public StudyProgram Program { get; set; }
        public AgeRange AgeRange { get; set; }
        public int? Males { get; set; }
        public int? Females { get; set; }
        public GeographicalLocation GeographicalLocation { get; set; }

        public Disability Disability { get; set; }
    }
}
