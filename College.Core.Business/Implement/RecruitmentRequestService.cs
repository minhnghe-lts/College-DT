using College.Core.Business.Interface;
using College.Core.Entities;
using College.Core.Infrastructure;
using College.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace College.Core.Business.Implement
{
    public class RecruitmentRequestService : IRecruitmentRequestService
    {
        private readonly AppDbContext _myDbContext;

        public RecruitmentRequestService(AppDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        // Lấy danh sách yêu cầu tuyển dụng
        public async Task<IEnumerable<RecruitmentRequestModel>> GetRecruitment()
        {
            try
            {
                var getRecruitment = await _myDbContext.RecruitmentRequest.AsNoTracking()
                .Select(x => new RecruitmentRequestModel
                {
                    Description = x.Description,
                    FromDate = x.FromDate,
                    ToDate = x.ToDate
                }).ToListAsync();
                return getRecruitment;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Lỗi: {e.Message}");
                throw;
            }
        }

        // Tạo yêu cầu tuyển dụng
        public async Task<RecruitmentRequestModel> AddRecruitment(RecruitmentRequestModel requestModel)
        {
            try
            {
                ValidDate(requestModel.FromDate, requestModel.ToDate); // check validDate datetime 
                RecruitmentRequest recruitmentRequest = new RecruitmentRequest
                {
                    Description = requestModel.Description,
                    FromDate = requestModel.FromDate,
                    ToDate = requestModel.FromDate
                };
                _myDbContext.RecruitmentRequest.Add(recruitmentRequest);
                return requestModel;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Lỗi: {e.Message}");
                throw;
            }
        }

        // Xóa theo danh sách yêu cầu tuyển dụng
        public async Task<string> DeleteMultipleRecruitment(List<long> ids)
        {
            return await DeleteSoftOrNo(ids, false);
        }

        public Task<RecruitmentRequestModel> FillRecruitment(string nameFill)
        {
            throw new NotImplementedException();
        }

        // Tìm kiếm yêu cầu tuyển dụng từ mô tả (Description)
        public async Task<List<RecruitmentRequestModel>> SearchRecruitment(string keyword)
        {
            try
            {
                var results = await _myDbContext.RecruitmentRequest
                .Where(item => item.Description.Contains(keyword)).ToListAsync();
                return ConvertListModelToEntity(results);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Lỗi: {e.Message}");
                throw;
            }
        }

        // Cập nhật yêu cầu tuyển dụng
        public async Task<RecruitmentRequestModel> UpdateRecruitment(RecruitmentRequestModel requestModel)
        {
            try
            {
                if (requestModel.Id == 0 || requestModel.Id == null)
                {
                    throw new ArgumentException("id phải lớn hơn 0 hoặc khác null", nameof(requestModel.Id));
                }
                var findRecruitment = await _myDbContext.RecruitmentRequest.FindAsync(requestModel.Id);
                if (findRecruitment != null)
                {
                    ValidDate(requestModel.FromDate, requestModel.ToDate);
                    // Thay đổi giá trị các trường của yêu cầu tuyển dụng
                    findRecruitment.Description = requestModel.Description;
                    findRecruitment.FromDate = requestModel.FromDate;
                    findRecruitment.ToDate = requestModel.ToDate;
                    // End
                    _myDbContext.RecruitmentRequest.Update(findRecruitment);
                    return requestModel;
                }
                throw new ArgumentException("Không tìm thấy yêu cầu tuyển dụng", nameof(findRecruitment));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Lỗi: {e.Message}");
                throw;
            }
        }

        // check ngày tháng năm của yêu cầu tuyển dụng
        private async void ValidDate(DateTime fromDate, DateTime toDate)
        {
            DateTime currentDate = DateTime.Now;
            if (fromDate < currentDate)
            {
                throw new ArgumentException("Ngày bắt đầu phải từ ngày " + currentDate.ToString("dd-MM-yyyy") + " trở đi", nameof(fromDate));
            }
            else if (toDate <= fromDate)
            {
                throw new ArgumentException("Ngày kết thúc phải sau ngày bắt đầu", nameof(toDate));
            }
        }

        // Convert List model Recruitment sang List entity Recruitment
        public List<RecruitmentRequestModel> ConvertListModelToEntity(List<RecruitmentRequest> entities)
        {
            return entities.Select(entity => new RecruitmentRequestModel
            {
                Description = entity.Description,
                FromDate = entity.FromDate,
                ToDate = entity.ToDate
                // Map other properties as needed...
            }).ToList();
        }

        public async Task<string> SoftDeleteMultipleRecruitment(List<long> ids)
        {
            return await DeleteSoftOrNo(ids, true);
        }

        // xóa trong data hoặc xóa trạng thái
        private async Task<string> DeleteSoftOrNo(List<long> ids, bool isSoftDelete)
        {
            try
            {
                if (ids.IsNullOrEmpty())
                {
                    throw new ArgumentException("Không tìm thấy yêu cầu tuyển dụng cần xóa", nameof(ids.Count));
                }
                string text = "";
                for (int i = 0; i < ids.Count; i++)
                {
                    var recruitmentRequest = await _myDbContext.RecruitmentRequest.FindAsync(ids[i]);
                    if (recruitmentRequest == null)
                    {
                        text += ids[i] + " ";
                        continue;
                    }

                    if (isSoftDelete)
                    {
                        recruitmentRequest.IsDeleted = true;
                    }
                    else
                    {
                        _myDbContext.RecruitmentRequest.Remove(recruitmentRequest);
                    }
                    await _myDbContext.SaveChangesAsync();
                }
                return text.Length == 0 ? "Xóa thành công" : "Không tìm thấy yêu cầu tuyển dụng có id: " + text;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Lỗi: {e.Message}");
                return $"Lỗi: {e.Message}";
                throw;
            }
        }
    }
}