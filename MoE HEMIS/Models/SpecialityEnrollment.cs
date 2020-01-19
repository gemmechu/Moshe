using System.ComponentModel.DataAnnotations.Schema;

namespace MoE_HEMIS.Models
{

    public class SpecialityEnrollment : Enrollment 
{
        public string FieldOfSpecialization { get; set; }
    }
}
