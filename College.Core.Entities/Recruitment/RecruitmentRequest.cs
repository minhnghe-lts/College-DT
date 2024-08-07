using College.Commons;

namespace College.Core.Entities
{
    public class RecruitmentRequest : BaseEntitySoftDeletable
    {
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public virtual ICollection<RecruitmentRequestDetail> Details { get; set; }
    }
}
