using College.Core.Business.Interface;
using College.Core.Models.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace College.Core.API.Controllers
{
    [Route("api/interviews")]
    [ApiController]
    public class InteviewController : ControllerBase
    {
        private readonly IInterviewService _interviewService;
        public InteviewController(IInterviewService interviewService)
        {
                _interviewService = interviewService;
        }
        [HttpGet]
        public async Task<IActionResult> GetInterviewCalander()
        {
            try
            {
                var result = await _interviewService.GetInterviewCalanders();
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInterviewCalander(long id)
        {
            try
            {
                var result = await _interviewService.GetInterviewCalander(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddInterviewCalander(AddInterViewModel interviewCalander)
        {
            try
            {
                var result = await _interviewService.AddInterView(interviewCalander);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInterviewCalander(UpdateInterViewModel interviewCalander, long id)
        {
            try
            {
                var result = await _interviewService.UpdateInterView(interviewCalander,id);
                if (result == null) 
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> SoftDeleteInterviewCalander(long id)
        {
            try
            {
                var result = await _interviewService.SoftDelInterView(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> SoftDeleteInterviewCalanders(List<long> id)
        {
            try
            {
                var result = await _interviewService.SoftDelInterViews(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterviewCalander(long id)
        {
            try
            {
                var result = await _interviewService.DelInterView(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
