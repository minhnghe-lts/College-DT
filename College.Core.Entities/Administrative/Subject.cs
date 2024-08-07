using College.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Core.Entities
{
    public class Subject : BaseEntitySoftDeletable
    {
        public long DepartmentId { get; set; }
        public virtual Department Department { get; set; }

    }
}
