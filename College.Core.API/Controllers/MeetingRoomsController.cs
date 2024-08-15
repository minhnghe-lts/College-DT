using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using College.Core.Entities;
using College.Core.Infrastructure;
using System.Reflection.Metadata;
using College.Core.Business.Interface;
using College.Core.Models.RequestModel;

namespace College.Core.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MeetingRoomsController : ControllerBase
    {
        private readonly IMeetingRoomServices _meetingRoomServices;

        public MeetingRoomsController(IMeetingRoomServices meetingRoomServices)
        {
            _meetingRoomServices = meetingRoomServices;
        }

        // GET: api/MeetingRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingRoom>>> GetMeetingRoom()
        {
            try
            {
                var result = await _meetingRoomServices.GetMeetingRooms();
                if (result == null) { return NotFound(); }
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET: api/MeetingRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingRoom>> GetMeetingRoom(long id)
        {
            try
            {
                var result = await _meetingRoomServices.GetMeetingRoom(id);
                if (result == null) { return NotFound(); }
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // PUT: api/MeetingRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeetingRoom(long id, UpdateMeetingRoom meetingRoom)
        {
            if (id != meetingRoom.Id)
            {
                return BadRequest();
            }
            try
            {
                var result = await _meetingRoomServices.UpdateMeettingRoom(meetingRoom);
                if (result == null) { return NotFound(); }
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST: api/MeetingRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MeetingRoom>> PostMeetingRoom(AddMeetinngRoom meetingRoom)
        {
            try
            {
                var result = await _meetingRoomServices.AddMeettingRoom(meetingRoom);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE: api/MeetingRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteMeetingRoom(long id)
        {
            try
            {
                var result = await _meetingRoomServices.SoftDelMeetingRoom(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
