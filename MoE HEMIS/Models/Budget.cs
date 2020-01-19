using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class Budget
    {
        public int BudgetId { get; set; }
        public College College { get; set; }
        public int? CollegeId { get; set; }
        public decimal Allocated { get; set; }
        public decimal Additional { get; set; }
        public decimal Utilized { get; set; }
        public BudgetType BudgetType { get; set; }
        public virtual BudgetDescription BudgetDescription { get; set; }
        public int BudgetDescriptionId { get; set; }
    }

    public enum BudgetType
    {
        RECURRENT, CAPITAL
    }
}
