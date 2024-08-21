using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static College.Commons.CommonEnums;

namespace College.Core.Models
{
    public class CreateEditContractRequestModel
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public long PositionId { get; set; }
        public long DepartmentId { get; set; }
        public EmployeeContractType employeeContractType { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal PerformanceSalary { get; set; }
        public List<ContractAllowanceReqModel> Allowances { get; set; }
    }
}
