using System.ComponentModel.DataAnnotations.Schema;

namespace MoE_HEMIS.Models
{
    public class CompletionRate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompletionRateId { get; set; }

        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }


        public double? FirstToSecond { get; set; }
        public double? SecondToThird { get; set; }
        public double? ThirdToFourth { get; set; }
        public double? FourthToFifth { get; set; }
        public double? FifthToSixth { get; set; }
        public double? SixthToSeventh { get; set; }
    }


}
