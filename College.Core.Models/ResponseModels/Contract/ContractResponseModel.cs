using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static College.Commons.CommonEnums;

namespace College.Core.Models
{
    public class ContractResponseModel
    {
        public long Id { get; set; }
        public string EmployeeName { get; set; }
        public string PositionName { get; set; }
        public string DepartmentName { get; set; }
        public EmployeeContractType EmployeeContractType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
