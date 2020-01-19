using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class UnjustifiableExpense
    {
        public int UnjustifiableExpenseId { get; set; }
        public Institution Institution { get; set; }
        public int? InstitutionId { get; set; }
        public decimal Amount { get; set; }
       
    }


}
