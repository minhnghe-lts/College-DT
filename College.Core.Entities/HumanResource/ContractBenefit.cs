using College.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Core.Entities
{
    public class ContractBenefit : BaseEntity
    {
        public long ContractId { get; set; }
        public virtual Contract Contract { get; set; }
        public long BenefitId { get; set; }
        public virtual Benefit Benefit { get; set; }
    }
}
