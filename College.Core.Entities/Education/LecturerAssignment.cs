using College.Commons;

namespace College.Core.Entities
{
    public class LecturerAssignment : BaseEntitySoftDeletable
    {
        public long EducationMasterPlanId { get; set; }
        public virtual EducationMasterPlan EducationMasterPlan { get; set; }
        public long EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public long CourseId { get; set; }
        public virtual Course Course { get; set; }

    }
}
