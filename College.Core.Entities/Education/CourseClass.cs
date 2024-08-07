using College.Commons;

namespace College.Core.Entities
{
    public class CourseClass : BaseMasterData
    {
        public long EducationMasterPlanId { get; set; }
        public virtual EducationMasterPlan EducationMasterPlan { get; set; }
        public long CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
