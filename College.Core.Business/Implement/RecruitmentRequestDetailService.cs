using College.Core.Business.Interface;
using College.Core.Entities;
using College.Core.Infrastructure;
using College.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace College.Core.Business.Implement
{
    public class RecruitmentRequestDetailService : IRecruitmentRequestDetailService
    {
        private readonly AppDbContext _myDbContext;

        public RecruitmentRequestDetailService(AppDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public async Task<List<RecruitmentRequestDetailModel>> AddRecruitmentDetail(List<RecruitmentRequestDetailModel> requestDetailModels, long recruitmentRequest_Id)
        {
            try
            {
                var recruitmentRequest = await _myDbContext.RecruitmentRequest.FindAsync(recruitmentRequest_Id);
                if (recruitmentRequest != null)
                {
                    foreach (var model in requestDetailModels)
                    {
                        var recruitmentRequestDetail = new RecruitmentRequestDetail
                        {
                            RecruitmentRequest = recruitmentRequest,
                            RecruitmentRequestId = recruitmentRequest.Id,
                            Quantity = model.Quantity,
                            OptionalSkills = model.OptionalSkills,
                            RequiredSkills = model.RequiredSkills
                        };
                        _myDbContext.Add(recruitmentRequestDetail);
                    }
                    return requestDetailModels;
                }
                throw new ArgumentException("Không tìm thấy yêu cầu tuyển dụng", nameof(recruitmentRequest));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Lỗi: {e.Message}");
                throw;
            }
        }

        public async Task<string> DeleteMultipleRecruitmentDetail(List<long> ids)
        {
            try
            {
                if (ids.IsNullOrEmpty())
                {
                    throw new ArgumentException("Không tìm thấy chi tiết yêu cầu tuyển dụng cần xóa", nameof(ids.Count));
                }
                string text = "";
                for (int i = 0; i < ids.Count; i++)
                {
                    var recruitmentRequestDetail = await _myDbContext.RecruitmentRequestDetail.FindAsync(ids[i]);
                    if (recruitmentRequestDetail == null)
                    {
                        text += ids[i] + " ";
                        continue;
                    }
                    _myDbContext.RecruitmentRequestDetail.Remove(recruitmentRequestDetail);
                    await _myDbContext.SaveChangesAsync();
                }
                return text.Length == 0 ? "Xóa thành công" : "Không tìm thấy chi tiết yêu cầu tuyển dụng có id: " + text;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Lỗi: {e.Message}");
                throw;
            }
        }

        public async Task<List<RecruitmentRequestDetailModel>> GetRecruitmentDetail(long recruitmentRequest_Id)
        {
            try
            {
                var results = await _myDbContext.RecruitmentRequestDetail.AsNoTracking()
                .Where(rr => rr.RecruitmentRequestId == recruitmentRequest_Id).ToListAsync();
                return ConvertListModelToEntity(results);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Lỗi: {e.Message}");
                throw;
            }
        }

        public async Task<List<RecruitmentRequestDetailModel>> UpdateRecruitmentDetail(List<RecruitmentRequestDetailModel> requestDetailModels)
        {
            try
            {
                foreach (var model in requestDetailModels)
                {
                    var recruitmentRequestDetail = await _myDbContext.RecruitmentRequestDetail.FindAsync(model.Id);
                    recruitmentRequestDetail.OptionalSkills = model.OptionalSkills;
                    recruitmentRequestDetail.RequiredSkills = model.RequiredSkills;
                    recruitmentRequestDetail.Quantity = model.Quantity;
                    _myDbContext.Update(recruitmentRequestDetail);
                }
                return requestDetailModels;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Lỗi: {e.Message}");
                throw;
            }
        }

        public List<RecruitmentRequestDetailModel> ConvertListModelToEntity(List<RecruitmentRequestDetail> entities)
        {
            return entities.Select(entity => new RecruitmentRequestDetailModel
            {
                Id = entity.Id,
                RecruitmentRequestId = entity.RecruitmentRequestId,
                Quantity = entity.Quantity,
                OptionalSkills = entity.OptionalSkills,
                RequiredSkills = entity.RequiredSkills
            }).ToList();
        }
    }
}