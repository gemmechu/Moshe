using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }
        public Status Status { get; set; }
        public int? Institution { get; set; }
        public int? College { get; set; }
    }
    public enum Status
    {
        VALIDATED, UNVALIDATED
    }
}
