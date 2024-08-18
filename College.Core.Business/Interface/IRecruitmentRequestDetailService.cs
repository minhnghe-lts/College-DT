using College.Core.Models;

namespace College.Core.Business.Interface
{
    public interface IRecruitmentRequestDetailService
    {
        public Task<List<RecruitmentRequestDetailModel>> GetRecruitmentDetail(long recruitmentRequest_Id);
        public Task<List<RecruitmentRequestDetailModel>> AddRecruitmentDetail(List<RecruitmentRequestDetailModel> requestDetailModels, long recruitmentRequest_Id);
        public Task<List<RecruitmentRequestDetailModel>> UpdateRecruitmentDetail(List<RecruitmentRequestDetailModel> requestDetailModels);
        public Task<string> DeleteMultipleRecruitmentDetail(List<long> ids);
    }
}