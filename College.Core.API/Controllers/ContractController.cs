using College.Core.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static College.Commons.CommonEnums;

namespace College.Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet("GetContract")]
        public IActionResult GetContract()
        {
            var result = _contractService.ListContract();
            return Ok(result);
        }

        [HttpGet("GetContractByPositionId/{positionId}")]
        public IActionResult GetContractByPositionId(long positionId)
        {
            var result = _contractService.FindContractByPositionId(positionId);
            return Ok(result);
        }
        [HttpGet("GetContractByEmployeeContractType/{contractType}")]
        public IActionResult GetContractByEmployeeContractType(EmployeeContractType contractType)
        {
            var result = _contractService.FindContractByEmployeeContractType(contractType);
            return Ok(result);
        }
        [HttpGet("GetContractByDepartmentId/{departmentId}")]
        public IActionResult GetContractByDepartmentId(long departmentId)
        {
            var result = _contractService.FindContractByDepartmentId(departmentId);
            return Ok(result);
        }
    }
}
