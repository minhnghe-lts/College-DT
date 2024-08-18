using College.Core.Business.Interface;
using College.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace College.Core.API.Controllers
{
    [Route("api/interviews")]
    [ApiController]
    public class RecruitmentController : ControllerBase
    {
        private readonly IRecruitmentRequestService _recruitmentService;
        private readonly IRecruitmentRequestDetailService _recruitmentRequestDetailService;
        public RecruitmentController(IRecruitmentRequestService recruitmentService,
        IRecruitmentRequestDetailService recruitmentRequestDetailService)
        {
            _recruitmentService = recruitmentService;
            _recruitmentRequestDetailService = recruitmentRequestDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecruitmentRequest()
        {
            try
            {
                var result = await _recruitmentService.GetRecruitment();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRecruitmentRequest(RecruitmentRequestModel requestModel)
        {
            try
            {
                var result = await _recruitmentService.AddRecruitment(requestModel);
                if (result != null)
                {
                    await _recruitmentRequestDetailService.AddRecruitmentDetail((List<RecruitmentRequestDetailModel>)requestModel.Details, result.Id);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutRecruitmentRequest(RecruitmentRequestModel requestModel)
        {
            try
            {
                var result = await _recruitmentService.UpdateRecruitment(requestModel);
                if (result == null)
                {
                    return NotFound();
                }
                await _recruitmentRequestDetailService.UpdateRecruitmentDetail((List<RecruitmentRequestDetailModel>)requestModel.Details);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> SoftDeleteRecruitmentRequest(List<long> ids)
        {
            try
            {
                var result = await _recruitmentService.SoftDeleteMultipleRecruitment(ids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRecruitmentRequest(List<long> ids)
        {
            try
            {
                var result = await _recruitmentService.DeleteMultipleRecruitment(ids);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}