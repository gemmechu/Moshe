using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class Staff
    {
        public int StaffId { get; set; } 
        public string Name { get; set; }
        public string Nationality { get; set; }
        public bool IsExpatriate { get; set; }
        public decimal Salary { get; set; }
        public DateTime BirthDate { get; set; }
        [EnumDataType(typeof(AcademicLevel))]
        public AcademicLevel AcademicLevel { get; set; }
        [EnumDataType(typeof(Dedication))]
        public Dedication Ded { get; set; }
        [EnumDataType(typeof(Sex))]
        public Sex Sex { get; set; }
        [EnumDataType(typeof(EmploymentType))]
        public EmploymentType Employment { get; set; }
        public int ServiceYear { get; set; }

    }

    public enum AcademicLevel
    {
        BACHELORS,
        MD_DV,
        MASTERS,
        PHD,
        OTHERS
    }

    public enum Dedication
    {
        FULL_TIME, PART_TIME
    }

    public enum Sex
    {
        MALE, FEMALE
    }

    public enum EmploymentType
    {
        EMPLOYEE, CONTRACTOR
    }
}
