using College.Core.Entities;
using College.Core.Models.RequestModel;
using College.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Core.Business.Interface
{
    public interface IMeetingRoomServices
    {
        public Task<IEnumerable<MeetingRoomModel>> GetMeetingRooms();
        public Task<MeetingRoomModel> GetMeetingRoom(long id);
        public Task<MeetingRoom> AddMeettingRoom(AddMeetinngRoom Request);
        public Task<MeetingRoom> UpdateMeettingRoom(UpdateMeetingRoom Request);
        public Task<bool> SoftDelMeetingRoom(long id);
    }
}
