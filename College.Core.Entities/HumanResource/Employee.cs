namespace College.Core.Entities
{
    public class Employee : BasePersonalProfile
    {
        public long? CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }
        public bool IsActive { get; set; }
    }
}
