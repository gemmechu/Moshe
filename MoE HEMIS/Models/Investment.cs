using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class Investment
    {
        public int InvestmentId { get; set; }
        public College College { get; set; }
        public int? CollegeId { get; set; }
        public decimal CostIncurred { get; set; }
        public string Remark { get; set; }
        public InvestmentTitle InvestmentTitle { get; set; }
    }

    public enum InvestmentTitle
    {
        BUILDINGS,
        VEHICLES,
        EQUIPMENTS,
        FURNITURES,
        MACHINARIES_AND_PLANTS,
        EDUCATIONAL_MATERIALS,
        OTHERS
    }
}
