using College.Core.Models;
using College.Core.Models.RequestModels;
using College.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static College.Commons.CommonEnums;

namespace College.Core.Business
{
    public interface IContractService
    {
        Task<List<ContractResponseModel>> ListContract();
        Task<List<ContractResponseModel>> FindContractByPositionId(long positionId);
        Task<List<ContractResponseModel>> FindContractByEmployeeContractType(EmployeeContractType contractType);
        Task<List<ContractResponseModel>> FindContractByDepartmentId(long departmentId);
        Task<List<ContractResponseModel>> FindContractByDateRange(DateTime? fromDate, DateTime? toDate);
        //Task CreateEditContracts(CreateEditContractRequestModel input);
        Task<List<FillDropPosition>> FillDropDowPosition();
        Task<bool> DeteleContract(long contractId);
        string ExportContract(long contractId);
        Task<bool> CreateEditContracts(CreateEditContractRequestModel input);
        Task<List<FllDropEmployee>> FillDropEmployee();
    }
}
