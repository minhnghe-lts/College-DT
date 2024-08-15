using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static College.Commons.CommonEnums;

namespace College.Core.Models.RequestModel
{
    public class UpdateInterViewModel
    {
        public long id { get; set; }
        public string Name { get; set; }
        public InterviewResult Result { get; set; }
        public string ResultDescription { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public long MeetingRoomId { get; set; }
    }
}
