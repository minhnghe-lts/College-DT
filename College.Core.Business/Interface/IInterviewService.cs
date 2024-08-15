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
    public interface IInterviewService
    {
        public Task<IEnumerable<InterviewModel>> GetInterviewCalanders();
        public Task<InterviewModel> GetInterviewCalander(long id);
        public Task<Interview> AddInterView(AddInterViewModel requestModel);
        public Task<Interview> UpdateInterView(UpdateInterViewModel interviewCalander, long id);
        public Task<bool> DelInterView(long id);
        public Task<bool> SoftDelInterView(long id);

        public Task<bool> SoftDelInterViews(List<long> ids);


    }
}
