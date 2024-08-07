using College.Commons;
using static College.Commons.CommonEnums;

namespace College.Core.Entities
{
    public class EducationMasterPlan : BaseMasterData
    {
        public long EducationYearId { get; set; }
        public virtual EducationYear EducationYear { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Description { get; set; }
        public string ColorCode { get; set; }
        public MasterPlanType MasterPlanType { get; set; }
    }
}
