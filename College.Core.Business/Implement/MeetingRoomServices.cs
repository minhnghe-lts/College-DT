using College.Core.Business.Interface;
using College.Core.Entities;
using College.Core.Infrastructure;
using College.Core.Models.RequestModel;
using College.Core.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Core.Business.Implement
{
    public class MeetingRoomServices: IMeetingRoomServices
    {
        private readonly AppDbContext _myDbContext;

        public MeetingRoomServices(AppDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        // Lấy phòng phỏng vấn
        public async Task<IEnumerable<MeetingRoomModel>> GetMeetingRooms()
        {
            try
            {
                var MeetingRooms = await _myDbContext.MeetingRoom.AsNoTracking()
                    .Select(item => new MeetingRoomModel
                    {
                        Id = item.Id,
                        Description = item.Description,
                        IsDeleted = item.IsDeleted,
                        Name = item.Name
                    }).ToListAsync();
                if (MeetingRooms == null) {
                    return null;
                }
                return MeetingRooms;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Lỗi: {e.Message}");
                throw;
            }
        }

        public async Task<MeetingRoomModel> GetMeetingRoom(long id)
        {
            try
            {
                if (id <= 0 || id == null)
                {
                    throw new ArgumentException("id phải lớn hơn 0 hoặc khác null", nameof(id));
                }
                var MeetingRoom = await _myDbContext.MeetingRoom.AsNoTracking()
                    .Where(record => record.Id == id)
                    .Select(item => new MeetingRoomModel
                    {
                        Id = item.Id,
                        Description = item.Description,
                        IsDeleted = item.IsDeleted,
                        Name = item.Name
                    }).SingleOrDefaultAsync();
                if (MeetingRoom == null)
                {
                    return null;
                }
                return MeetingRoom;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Lỗi: {e.Message}");
                throw;
            }
        }

        public async Task<MeetingRoom> AddMeettingRoom(AddMeetinngRoom Request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Request.Description))
                {
                    throw new ArgumentException("Không được để trống hoặc null", nameof(Request.Description));
                }
                if (string.IsNullOrWhiteSpace(Request.Name))
                {
                    throw new ArgumentException("Không được để trống hoặc null", nameof(Request.Name));
                }

                var MeetingRoom = new MeetingRoom
                {
                    Description = Request.Description,
                    Name = Request.Name,
                    IsDeleted = false
                };
                _myDbContext.MeetingRoom.Add(MeetingRoom);
                await _myDbContext.SaveChangesAsync();
                return MeetingRoom;
            }
            catch (ArgumentNullException ex)
            { 
                throw new Exception(ex.Message);
            }
        }

        public async Task<MeetingRoom> UpdateMeettingRoom(UpdateMeetingRoom Request)
        {
            try
            {
                if (Request == null)
                {
                    throw new ArgumentNullException(nameof(Request), "Mô hình yêu cầu không được null.");
                }
                if (Request.Id == null && Request.Id <= 0)
                {
                    throw new ArgumentException("id không được null hoặc nhỏ hơn 0.", nameof(Request.Id));
                }
                if (string.IsNullOrWhiteSpace(Request.description))
                {
                    throw new ArgumentException("Không được để trống hoặc null", nameof(Request.description));
                }
                if (string.IsNullOrWhiteSpace(Request.Name))
                {
                    throw new ArgumentException("Không được để trống hoặc null", nameof(Request.Name));
                }
                var MeetingRoom = await _myDbContext.MeetingRoom.FirstOrDefaultAsync(record => record.Id == Request.Id);
                if (MeetingRoom == null)
                {
                    return null;
                }
                MeetingRoom.Description = Request.description;
                MeetingRoom.Name = Request.Name;
                await _myDbContext.SaveChangesAsync();
                return MeetingRoom;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> SoftDelMeetingRoom(long id)
        {
            try
            {
                if (id <= 0 || id == null)
                {
                    throw new ArgumentException("id phải lớn hơn 0 hoặc khác null", nameof(id));
                }
                var MeetingRoom = await _myDbContext.MeetingRoom.FindAsync(id);
                if (MeetingRoom != null)
                {
                    MeetingRoom.IsDeleted = true;
                    await _myDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
