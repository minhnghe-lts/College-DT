using College.Commons;

namespace College.Core.Entities
{
    public class Course : BaseMasterData
    {
        public int NumberOfCredits { get; set; }
        public int NumberOfLessons { get; set; }
    }
}
