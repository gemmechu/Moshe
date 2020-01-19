using System.ComponentModel.DataAnnotations.Schema;

namespace MoE_HEMIS.Models
{
    public class IntakeCapacity
    {
       
        public int IntakeCapacityId { get; set; }

        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }
        public int Capacity { get; set; }
    }


}
