using System;

namespace MoE_HEMIS.Models
{
    public  class CostSharingReport
{       
        public int CostSharingReportId { get; set; }       

        public virtual College College { get; set; }
        public int? CollegeId { get; set; }

        public string FullName { get; set; }
        public string StudentId { get; set; }
        public string TIN { get; set; }
        public Sex Sex { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string FieldOfStudy { get; set; }
        public DateTime ClearanceDate { get; set; }
        public Decimal TutionFee { get; set; }
        public Decimal FoodExpense { get; set; }
        public Decimal DormitoryExpense { get; set; }
        public Decimal PrePayment { get; set; }
        public string ReciptNumber { get; set; }
        public Decimal Unpaid { get; set; }
    }


}
