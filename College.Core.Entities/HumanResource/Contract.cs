using College.Commons;
using static College.Commons.CommonEnums;

namespace College.Core.Entities
{
    public class Contract : BaseEntitySoftDeletable
    {
        public long EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public EmployeeContractType EmployeeContractType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal PerformanceSalary { get; set; }
        public long DeparmentId { get; set; }
        public virtual Department Department { get; set; }
        public long SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public long PositionId { get; set; }
        public virtual Position Position { get; set; }
        public DateTime? TerminationDate { get; set; }
    }
}
