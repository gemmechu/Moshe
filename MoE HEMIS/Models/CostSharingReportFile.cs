using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class CostSharingReportFile
    {
        public int CostSharingReportFileId { get; set; }

        public virtual College College { get; set; }
        public int? CollegeId { get; set; }
        public string FilePath { get; set; }
    }
}
