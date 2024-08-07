namespace College.Core.Entities
{
    public class Candidate : BasePersonalProfile
    {
        public long RecruitmentRequestId { get; set; }
        public virtual RecruitmentRequest RecruitmentRequest { get; set; }
        public long JobTitleId { get; set; }
        public virtual JobTitle JobTitle { get; set; }
    }
}
