using College.Core.Models;

namespace College.Core.Business.Interface
{
    public interface IRecruitmentRequestService
    {
        public Task<IEnumerable<RecruitmentRequestModel>> GetRecruitment();
        public Task<RecruitmentRequestModel> AddRecruitment(RecruitmentRequestModel requestModel);
        public Task<RecruitmentRequestModel> UpdateRecruitment(RecruitmentRequestModel requestModel);
        public Task<string> DeleteMultipleRecruitment(List<long> ids);
        public Task<string> SoftDeleteMultipleRecruitment(List<long> ids);
        public Task<List<RecruitmentRequestModel>> SearchRecruitment(string keyword);
        public Task<RecruitmentRequestModel> FillRecruitment(string nameFill);
    }
}