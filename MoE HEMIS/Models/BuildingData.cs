using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoE_HEMIS.Models
{
    public class BuildingData
    {
        public int BuildingDataId { get; set; }
        public virtual College College { get; set; }
        public int? CollegeId { get; set; }

        public string NameOrCodeOfBuilding { get; set; }

        public bool IsForAdmin { get; set; }
        public bool IsForClassRooms { get; set; }
        public bool IsForLibrary { get; set; }
        public bool IsForDormitories { get; set; }
        public bool IsForStaffResidence { get; set; }
        public bool IsForWorkshop { get; set; }
        public bool IsForLaboratories { get; set; }
        public bool IsForCafetaria { get; set; }
        public bool IsForOtherPurpose { get; set; }

        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime CompletionDate { get; set; }

        public string NameOfContractor { get; set; }
        public string NameOfConsultant { get; set; }
        public Decimal Status { get; set; }

        public Decimal BudgetAllocated { get; set; }
        public Decimal FinancialStatus { get; set; }
    }
}
