using College.Commons;
using static College.Commons.CommonEnums;

namespace College.Core.Entities
{
    public class Interview : BaseMasterData
    {
        public long CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }
        public InterviewResult InterviewResult { get; set; }
        public string ResultDescription { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public long MeetingRoomId { get; set; }
        public virtual MeetingRoom MeetingRoom { get; set; }
        public DateTime? OnBoardDate { get; set; }
    }
}
