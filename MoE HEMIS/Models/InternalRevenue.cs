using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class InternalRevenue
    {
        public int InternalRevenueId { get; set; }
        public College College { get; set; }
        public int? CollegeId { get; set; }
        public decimal Income { get; set; }
        public decimal Expense { get; set; }
        public RevenueDescription Revenue { get; set; }

    }

    public enum RevenueDescription
    {
        FARMING,
        EDUCATION_PROGRAMS_TUTION_FEE,
        TRAINING_AND_CONSULTANCY,
        BUSINESS_ENTITIES,
        FUNDS,
        HOSPITAL_SERVICES,
        OTHERS_PAYABLE


    }
}
