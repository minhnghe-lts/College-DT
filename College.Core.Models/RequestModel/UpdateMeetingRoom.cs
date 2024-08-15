using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Core.Models.RequestModel
{
    public class UpdateMeetingRoom
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
    }
}
