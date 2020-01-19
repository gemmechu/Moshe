namespace MoE_HEMIS.Models
{
    public  class PostGraduateResearchPublication
{       
        public int PostGraduateResearchPublicationId { get; set; }

        public Publication Publication { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        public virtual Department Department { get; set; }
        public int? DepartmentId { get; set; }
    }


}
