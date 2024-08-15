using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static College.Commons.CommonEnums;

namespace College.Core.Models.RequestModel
{
    public class AddInterViewModel
    {
        public string name { get; set; }
        public long CandidateId { get; set; }
        public InterviewResult InterviewResult { get; set; }
        public string ResultDescription { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public long MeetingRoomId { get; set; }
    }
}
