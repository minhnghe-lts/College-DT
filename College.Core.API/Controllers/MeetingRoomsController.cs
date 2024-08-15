using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using College.Core.Entities;
using College.Core.Infrastructure;

namespace College.Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MeetingRoomsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MeetingRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingRoom>>> GetMeetingRoom()
        {
            return await _context.MeetingRoom.ToListAsync();
        }

        // GET: api/MeetingRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingRoom>> GetMeetingRoom(long id)
        {
            var meetingRoom = await _context.MeetingRoom.FindAsync(id);

            if (meetingRoom == null)
            {
                return NotFound();
            }

            return meetingRoom;
        }

        // PUT: api/MeetingRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeetingRoom(long id, MeetingRoom meetingRoom)
        {
            if (id != meetingRoom.Id)
            {
                return BadRequest();
            }

            _context.Entry(meetingRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingRoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MeetingRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MeetingRoom>> PostMeetingRoom(MeetingRoom meetingRoom)
        {
            _context.MeetingRoom.Add(meetingRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeetingRoom", new { id = meetingRoom.Id }, meetingRoom);
        }

        // DELETE: api/MeetingRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeetingRoom(long id)
        {
            var meetingRoom = await _context.MeetingRoom.FindAsync(id);
            if (meetingRoom == null)
            {
                return NotFound();
            }

            _context.MeetingRoom.Remove(meetingRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MeetingRoomExists(long id)
        {
            return _context.MeetingRoom.Any(e => e.Id == id);
        }
    }
}
