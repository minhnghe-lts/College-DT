using College.Commons;

namespace College.Core.Entities
{
    public class CourseCondition : BaseEntity
    {
        public long CourseId { get; set; }
        public virtual Course Course { get; set; }
        public long? RequiredCourseId { get; set; }
        public virtual Course RequiredCourse { get; set; }
        public int RequiredMinNumOfCredit { get; set; }
    }
}
