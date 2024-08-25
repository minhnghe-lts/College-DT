using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static College.Commons.CommonEnums;

namespace College.Core.Models.RequestModels
{
    public class RequestExportContract
    {
        public long id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public EmployeeContractType contractType { get; set; }
        public string Departments { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
