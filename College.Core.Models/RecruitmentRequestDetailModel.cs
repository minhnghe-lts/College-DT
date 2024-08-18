namespace College.Core.Models
{
    public class RecruitmentRequestDetailModel
    {
        public long Id { get; set; }
        public long RecruitmentRequestId { get; set; }
        public virtual RecruitmentRequestModel RecruitmentRequest { get; set; }
        public long JobTitleId { get; set; }
        // public virtual JobTitle JobTitle { get; set; }
        public long Quantity { get; set; }
        public string RequiredSkills { get; set; }
        public string OptionalSkills { get; set; }
    }
}