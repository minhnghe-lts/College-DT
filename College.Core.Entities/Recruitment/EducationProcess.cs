using College.Commons;

namespace College.Core.Entities
{
    public class EducationProcess : BaseEntity
    {
        public long? CandidateId { get; set; }
        public virtual Candidate? Candidate { get; set; }
        public string SchoolName { get; set; }
        public DateTime? GraduatedDate { get; set; }
        public decimal? GraduatedPoint { get; set; }
        public string Degree { get; set; }
    }
}
