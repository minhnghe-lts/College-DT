namespace College.Core.Models
{
    public class RecruitmentRequestModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public virtual ICollection<RecruitmentRequestDetailModel> Details { get; set; }
    }
}