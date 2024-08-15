using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static College.Commons.CommonEnums;

namespace College.Core.Models.ResponseModels
{
    public class InterviewModel
    {
        public long Id { get; set; }
        public long CandidateId { get; set; }
        public long MeetingRoomId { get; set; }
        public string CandidateName { get; set; }
        public string MeetingRoomName { get; set; }
        public string Name { get; set; }
        public InterviewResult Result { get; set; }
        public string ResultDescription { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
    }
}
