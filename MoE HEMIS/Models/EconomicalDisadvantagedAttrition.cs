﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class EconomicalDisadvantagedAttrition
{
        public int economicalDisadvantagedAttritionId { get; set; }

        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }

        public int Males { get; set; }
        public int Females { get; set; }

        public StudentAttritionCase Case { get; set; }
        public StudyProgram Program { get; set; }
        public StudyLevel Level { get; set; } = StudyLevel.UNDERGRADUATE;

        public EconomicQuintile Quintal { get; set; }
    }
}
