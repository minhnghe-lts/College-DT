using College.Commons;

namespace College.Core.Entities
{
    public class CourseSubject : BaseEntitySoftDeletable
    {
        public long CourseId { get; set; }
        public virtual Course Course { get; set; }
        public long SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
