using College.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Core.Entities
{
    public class ContractAllowance : BaseEntity
    {
        public long ContractId { get; set; }
        public virtual Contract Contract { get; set; }
        public long AllowanceId { get; set; }
        public virtual Allowance Allowance { get; set; }
        public decimal Amount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
