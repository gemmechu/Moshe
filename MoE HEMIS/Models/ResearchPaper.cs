using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class ResearchPaper
    {
        public int ResearchPaperId { get; set; }
        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }

        public ResearchStatus Status { get; set; }

        public int NumberOfResearchPapersCompleted { get; set; }

        public int NumberOfMaleTeachersParticipated { get; set; }
        public int NumberOfFemaleTeachersParticipated { get; set; }

        public int NumberOfFemaleLeads { get; set; }

        public int NumberOfMaleTeachersFromOtherInstituteParticipated { get; set; }
        public int NumberOfFemaleTeachersFromOtherInstituteParticipated { get; set; }

        public int BudgetAllocated { get; set; }
        public int BudgetFromExternalFund { get; set; }
    }

}
