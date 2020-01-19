namespace MoE_HEMIS.Models
{
    public  class StaffPublication
{       
        public int StaffPublicationId { get; set; }

        public AcademicStaff AcademicStaff { get; set; }
        public int AcademicStaffId { get; set; }
        public Publication Publication { get; set; }
        public string Title { get; set; }

        public virtual Department Department { get; set; }
        public int? DepartmentId { get; set; }
    }


}
