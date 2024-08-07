using College.Commons;

namespace College.Core.Entities
{
    public class LecturerAssignmentSchedule : BaseEntitySoftDeletable
    {
        public long LecturerAssignmentId { get; set; }
        public virtual LecturerAssignment LecturerAssignment { get; set; }
        public long CourseClassId { get; set; }
        public virtual CourseClass CourseClass { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int FromLessonPeriod { get; set; }
        public int ToLessonPeriod { get; set; }
    }
}
