using College.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Core.Entities.HumanResource
{
    public class EmployeeSalary : BaseEntitySoftDeletable
    {
        public long EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal InsuranceAmount { get; set; }
        public decimal PerformanceSalary { get; set; }
        public decimal HourlyRate { get; set; }
        public DateTime EffectiveDate { get; set; }

    }
}
