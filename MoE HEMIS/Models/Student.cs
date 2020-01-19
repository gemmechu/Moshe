using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class Student
    {
        public int StudentId { get; set; }
       public virtual Department Department { get; set; }
        public int? DepartmentId { get; set; }
       

        public string Name { get; set; }

        public string Phone { get; set; }

        public string StudentInstitutionId { get; set; }
        //TODO 
        //Correct Typo Bithdate 
        [Column(TypeName = "Date")]
        public DateTime Bithdate { get; set; }

        public string Remark { get; set; }

        public Sex Sex { get; set; }

        public StudyProgram Program { get; set; }

        public StudyLevel Level { get; set; }

    }

}
