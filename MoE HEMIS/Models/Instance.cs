using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class Instance
{
        public int InstanceId { get; set; }
        public int Year { get; set; }
        public Semester Semester { get; set; }    
    }

    public enum Semester { ONE, TWO, THREE}
}
