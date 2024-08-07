using College.Core.Entities;
using College.Core.Entities.HumanResource;
using Microsoft.EntityFrameworkCore;

namespace College.Core.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Ward> Ward { get; set; }
        public DbSet<WorkShift> WorkShift { get; set; }
        public DbSet<AdministrativeRegion> AdministrativeRegion { get; set; }
        public DbSet<AdministrativeUnit> AdministrativeUnit { get; set; }
        public DbSet<Allowance> Allowance { get; set; }
        public DbSet<Benefit> Benefit { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<JobTitle> JobTitle { get; set; }
        public DbSet<MeetingRoom> MeetingRoom { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<RequestType> RequestType { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<LecturerAssignment> LecturerAssignment { get; set; }
        public DbSet<LecturerAssignmentSchedule> LecturerAssignmentSchedule { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseClass> CourseClass { get; set; }
        public DbSet<CourseCondition> CourseCondition { get; set; }
        public DbSet<CourseDepartment> CourseDepartment { get; set; }
        public DbSet<CourseSubject> CourseSubject { get; set; }
        public DbSet<EducationMasterPlan> EducationMasterPlan { get; set; }
        public DbSet<EducationYear> EducationYear { get; set; }
        public DbSet<ContractBenefit> ContractBenefit { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalary { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<ContractAllowance> ContractAllowance { get; set; }
        public DbSet<Interview> Interview { get; set; }
        public DbSet<RecruitmentRequest> RecruitmentRequest { get; set; }
        public DbSet<RecruitmentRequestDetail> RecruitmentRequestDetail { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<EducationProcess> EducationProcess { get; set; }
    }
}
