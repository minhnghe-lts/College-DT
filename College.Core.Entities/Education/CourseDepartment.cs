using College.Commons;

namespace College.Core.Entities
{
    public class CourseDepartment : BaseEntitySoftDeletable
    {
        public long CourseId { get; set; }
        public virtual Course Course { get; set; }
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
