using College.Core.Business.Interface;
using College.Core.Entities;
using College.Core.Infrastructure;
using College.Core.Models.RequestModel;
using College.Core.Models.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace College.Core.Business.Implement
{

    public class InterviewService : IInterviewService
    {
        private readonly AppDbContext _myDbContext;

        public InterviewService(AppDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        // Lấy lịch phỏng vấn
        public async Task<IEnumerable<InterviewModel>> GetInterviewCalanders()
        {
            try
            {
                var getInterView = await _myDbContext.Interview.AsNoTracking()
                    .Select(x => new InterviewModel
                    {
                        Id = x.Id,
                        CandidateName = x.Candidate.FullName,
                        Name = x.Name,
                        Result = x.InterviewResult,
                        ResultDescription = x.ResultDescription,
                        FromTime = x.FromTime,
                        ToTime = x.ToTime,
                        MeetingRoomName = x.MeetingRoom.Name
                    }).ToListAsync();
                return getInterView;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Lỗi: {e.Message}");
                throw;
            }
        }
        public async Task<InterviewModel> GetInterviewCalander(long id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("id phải lớn hơn 0", nameof(id));
                }
                var GetInterView = await _myDbContext.Interview.AsNoTracking()
                    .Where(record => record.Id == id)
                    .Select(item => new InterviewModel
                    {
                        Id = item.Id,
                        CandidateName = item.Candidate.FullName,
                        Name = item.Name,
                        Result = item.InterviewResult,
                        ResultDescription = item.ResultDescription,
                        FromTime = item.FromTime,
                        ToTime = item.ToTime,
                        MeetingRoomName = item.MeetingRoom.Name
                    }).SingleOrDefaultAsync();
                return GetInterView;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Lỗi: {e.Message}");
                throw;
            }
        }
        // check null
        #region
        private async void ValidateAddInterViewModel(AddInterViewModel requestModel)
        {

            if (requestModel == null)
            {
                throw new ArgumentNullException(nameof(requestModel), "Mô hình yêu cầu không được null.");
            }

            if (string.IsNullOrWhiteSpace(requestModel.name))
            {
                throw new ArgumentException("Tên không được null hoặc trống.", nameof(requestModel.name));
            }

            if (requestModel.FromTime == default)
            {
                throw new ArgumentException("Thời gian bắt đầu không được là giá trị mặc định.", nameof(requestModel.FromTime));
            }

            if (requestModel.ToTime == default)
            {
                throw new ArgumentException("Thời gian kết thúc không được là giá trị mặc định.", nameof(requestModel.ToTime));
            }

            if (requestModel.InterviewResult < 0)
            {
                throw new ArgumentException("Kết quả phải lớp hơn 0", nameof(requestModel.InterviewResult));
            }

            if (string.IsNullOrWhiteSpace(requestModel.ResultDescription))
            {
                throw new ArgumentException("Không được để trống hoặc null", nameof(requestModel.ResultDescription));
            }
        }
        private async void ValidateUpdateInterViewModel(UpdateInterViewModel requestModel)
        {
            if (requestModel == null)
            {
                throw new ArgumentNullException(nameof(requestModel), "Mô hình yêu cầu không được null.");
            }
            if (requestModel.id == null && requestModel.id <= 0)
            {
                throw new ArgumentException("id không được null hoặc nhỏ hơn 0.", nameof(requestModel.Name));
            }
            if (string.IsNullOrWhiteSpace(requestModel.Name))
            {
                throw new ArgumentException("Tên không được null hoặc trống.", nameof(requestModel.Name));
            }

            if (requestModel.FromTime == default)
            {
                throw new ArgumentException("Thời gian bắt đầu không được là giá trị mặc định.", nameof(requestModel.FromTime));
            }

            if (requestModel.ToTime == default)
            {
                throw new ArgumentException("Thời gian kết thúc không được là giá trị mặc định.", nameof(requestModel.ToTime));
            }

            if (requestModel.Result < 0)
            {
                throw new ArgumentException("Kết quả phải lớp hơn 0", nameof(requestModel.Result));
            }

            if (string.IsNullOrWhiteSpace(requestModel.ResultDescription))
            {
                throw new ArgumentException("Không được để trống hoặc null", nameof(requestModel.ResultDescription));
            }
        }
        #endregion
        // them lich phong van
        public async Task<Interview> AddInterView(AddInterViewModel requestModel)
        {
            try
            {
                ValidateAddInterViewModel(requestModel);
                var candidateExists = await _myDbContext.Candidate.AsNoTracking()
                .AnyAsync(c => c.Id == requestModel.CandidateId);
                var meetingRoomExists = await _myDbContext.MeetingRoom.AsNoTracking()
                    .AnyAsync(m => m.Id == requestModel.MeetingRoomId);
                if (!candidateExists)
                {
                    throw new InvalidOperationException($"Ứng viên với ID {requestModel.CandidateId} không tồn tại.");
                }
                if (!meetingRoomExists)
                {
                    throw new InvalidOperationException($"Phòng họp với ID {requestModel.MeetingRoomId} không tồn tại.");
                }
                var AddInterView = new Interview
                {
                    Name = requestModel.name,
                    CandidateId = requestModel.CandidateId,
                    ResultDescription = requestModel.ResultDescription,
                    InterviewResult = requestModel.InterviewResult,
                    FromTime = requestModel.FromTime,
                    ToTime = requestModel.ToTime,
                    MeetingRoomId = requestModel.MeetingRoomId,
                    IsDeleted = false
                };
                _myDbContext.Interview.Add(AddInterView);
                await _myDbContext.SaveChangesAsync();
                return AddInterView;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        // update lich phong van 
        public async Task<Interview> UpdateInterView(UpdateInterViewModel requestModel, long id)
        {
            try
            {
                if(requestModel.id != id)
                {
                    throw new ArgumentException("Bạn không được phép thay đổi id", nameof(id));
                }
                var findInterview = await _myDbContext.Interview.FindAsync(requestModel.id);
                if (findInterview != null)
                {
                    ValidateUpdateInterViewModel(requestModel);
                    // Kiểm tra xem MeetingRoomId có tồn tại trong cơ sở dữ liệu không
                    var meetingRoomExists = await _myDbContext.MeetingRoom.AsNoTracking().AnyAsync(m => m.Id == requestModel.MeetingRoomId);
                    if (!meetingRoomExists)
                    {
                        throw new InvalidOperationException($"Phòng họp với ID {requestModel.MeetingRoomId} không tồn tại.");
                    }
                    findInterview.MeetingRoomId = requestModel.MeetingRoomId;
                    findInterview.Name = requestModel.Name;
                    findInterview.ResultDescription = requestModel.ResultDescription;
                    findInterview.InterviewResult = requestModel.Result;
                    findInterview.FromTime = requestModel.FromTime;
                    findInterview.ToTime = requestModel.ToTime;
                    _myDbContext.Interview.Update(findInterview);
                    await _myDbContext.SaveChangesAsync();
                    return findInterview;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        // danh dau xoa lich phong van
        public async Task<bool> SoftDelInterView(long id)
        {
            try
            {
                if (id <= 0 || id == null)
                {
                    throw new ArgumentException("id phải lớn hơn 0 hoặc khác null", nameof(id));
                }
                var findInterview = await _myDbContext.Interview.FindAsync(id);
                if (findInterview != null)
                {
                    findInterview.IsDeleted = true;
                    await _myDbContext.SaveChangesAsync();
                    return true;
                }
                throw new ArgumentException("Không tìm thấy lịch phỏng vấn", nameof(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        // xoa han lich phong van
        public async Task<bool> DelInterView(long id)
        {
            try
            {
                if (id <= 0 || id == null)
                {
                    throw new ArgumentException("id phải lớn hơn 0 hoặc khác null", nameof(id));
                }
                var findInterview = await _myDbContext.Interview.FindAsync(id);
                if (findInterview != null)
                {
                    _myDbContext.Interview.Remove(findInterview);
                    await _myDbContext.SaveChangesAsync();
                    return true;
                }
                throw new ArgumentException("Không tìm thấy lịch phỏng vấn", nameof(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        // danh dau  xoa nhieu lich phong van
        public async Task<bool> SoftDelInterViews(List<long> ids)
        {
            try
            {
                if (ids == null || !ids.Any())
                {
                    throw new ArgumentException("Danh sách ID không được null hoặc rỗng", nameof(ids));
                }

                var interviews = await _myDbContext.Interview
                                       .Where(c => ids.Contains(c.Id))
                                       .ToListAsync();

                if (interviews.Any())
                {
                    foreach (var item in interviews)
                    {
                        item.IsDeleted = true;
                    }
                    await _myDbContext.SaveChangesAsync();
                    return true;
                }
                throw new ArgumentException("Danh sách lịch phỏng vấn của bạn sai rồi");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
