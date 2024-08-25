using College.Core.Business;
using College.Core.Models;
using College.Core.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static College.Commons.CommonEnums;

namespace College.Core.API.Controllers
{
    [Route(Commons.CommonConstants.DefaultValue.DEFAULT_CONTROLLER_ROUTER)]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }
        [HttpGet]
        public IActionResult GetContract()
        {
            var result = _contractService.ListContract();
            return Ok(result);
        }
        [HttpGet]
        public IActionResult FillDropDowPosition()
        {
            var result = _contractService.FillDropDowPosition();
            return Ok(result);
        }
        [HttpGet("{positionId}")]
        public IActionResult GetContractByPositionId(long positionId)
        {
            var result = _contractService.FindContractByPositionId(positionId);
            return Ok(result);
        }
        [HttpGet("{contractType}")]
        public IActionResult GetContractByEmployeeContractType(EmployeeContractType contractType)
        {
            var result = _contractService.FindContractByEmployeeContractType(contractType);
            return Ok(result);
        }
        [HttpGet("{departmentId}")]
        public IActionResult GetContractByDepartmentId(long departmentId)
        {
            var result = _contractService.FindContractByDepartmentId(departmentId);
            return Ok(result);
        }

        [HttpPatch("{contractId}")]
        public async Task<IActionResult> DeleteContract(long contractId)
        {
            var result = await _contractService.DeteleContract(contractId);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult ExportContract([FromBody] long contractId)
        {
            string outputPath = _contractService.ExportContract(contractId);
            return PhysicalFile(outputPath, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "contract.docx");
        }

        [HttpPut]
        public async Task<IActionResult> CreateEditContract(CreateEditContractRequestModel input)
        {
            var result = await _contractService.CreateEditContracts(input);
            return Ok(result);
        }
    }
}
