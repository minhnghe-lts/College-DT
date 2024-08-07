using College.Commons;

namespace College.Core.Entities
{
    public class RecruitmentRequestDetail : BaseEntity
    {
        public long RecruitmentRequestId { get; set; }
        public virtual RecruitmentRequest RecruitmentRequest { get; set; }
        public long JobTitleId { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        public long Quantity { get; set; }
        public string RequiredSkills { get; set; }
        public string OptionalSkills { get; set; }
    }
}
