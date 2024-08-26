using College.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static College.Commons.CommonEnums;

namespace College.Core.Infrastructure
{
    public partial class SeedData
    {
        public static void SeedContract(AppDbContext context)
        {
            if (!context.Department.Any())
            {
                using(var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var departments = new List<Department>
                        {
                            new Department { Id = 1, Name = "Phòng Kinh Doanh", ParentId = null },
                            new Department { Id = 2, Name = "Phòng Kỹ Thuật", ParentId = null },
                            new Department { Id = 3, Name = "Phòng Nhân Sự", ParentId = null },
                            new Department { Id = 4, Name = "Phòng Tài Chính", ParentId = null },
                            new Department { Id = 5, Name = "Phòng Marketing", ParentId = null },
                        };
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Department] ON");
                        context.Department.AddRange(departments);
                        context.SaveChanges();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Department] OFF");
                        transaction.Commit();

                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }    
            }
            if (!context.Position.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var positions = new List<Position>
                        {
                            new Position { Id = 1, Name = "Nhân Viên Kinh Doanh" },
                            new Position { Id = 2, Name = "Kỹ Sư Phần Mềm" },
                            new Position { Id = 3, Name = "Chuyên Viên Nhân Sự" },
                            new Position { Id = 4, Name = "Kế Toán Trưởng" },
                            new Position { Id = 5, Name = "Chuyên Viên Marketing" },
                        };
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Position] ON");
                        context.Position.AddRange(positions);
                        context.SaveChanges();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Position] OFF");
                        transaction.Commit();
                    }
                    catch(Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }    
            }
            if(!context.Subject.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var subjects = new List<Subject>
                        {
                            new Subject { Id = 1, DepartmentId = 1 },
                            new Subject { Id = 2, DepartmentId = 2 },
                            new Subject { Id = 3, DepartmentId = 3 },
                            new Subject { Id = 4, DepartmentId = 4 },
                            new Subject { Id = 5, DepartmentId = 5 },
                        };
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Subject] ON");
                        context.Subject.AddRange(subjects);
                        context.SaveChanges();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Subject] OFF");
                        transaction.Commit();
                    }
                    catch (Exception) 
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            if (!context.JobTitle.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var jobTitles = new List<JobTitle>
                        {
                            new JobTitle { Id = 1, Name = "Nhân Viên Kinh Doanh" },
                            new JobTitle { Id = 2, Name = "Kỹ Sư Phần Mềm" },
                            new JobTitle { Id = 3, Name = "Chuyên Viên Nhân Sự" },
                            new JobTitle { Id = 4, Name = "Kế Toán Trưởng" },
                            new JobTitle { Id = 5, Name = "Chuyên Viên Marketing" }
                        };
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[JobTitle] ON");
                        context.JobTitle.AddRange(jobTitles);
                        context.SaveChanges();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[JobTitle] OFF");
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            if (!context.RecruitmentRequest.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var recruitmentRequests = new List<RecruitmentRequest>
                        {
                            new RecruitmentRequest
                            {
                                Id = 1,
                                Description = "Cần tuyển Nhân Viên Kinh Doanh",
                                FromDate = new DateTime(2024, 1, 1),
                                ToDate = new DateTime(2024, 3, 31)
                            },
                            new RecruitmentRequest
                            {
                                Id = 2,
                                Description = "Tuyển dụng Kỹ Sư Phần Mềm",
                                FromDate = new DateTime(2024, 2, 1),
                                ToDate = new DateTime(2024, 4, 30)
                            },
                            new RecruitmentRequest
                            {
                                Id = 3,
                                Description = "Tìm kiếm Chuyên Viên Nhân Sự",
                                FromDate = new DateTime(2024, 3, 1),
                                ToDate = new DateTime(2024, 5, 31)
                            },
                            new RecruitmentRequest
                            {
                                Id = 4,
                                Description = "Tuyển Kế Toán Trưởng",
                                FromDate = new DateTime(2024, 4, 1),
                                ToDate = new DateTime(2024, 6, 30)
                            },
                            new RecruitmentRequest
                            {
                                Id = 5,
                                Description = "Chuyên Viên Marketing cần tuyển",
                                FromDate = new DateTime(2024, 5, 1),
                                ToDate = new DateTime(2024, 7, 31)
                            }
                        };
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[RecruitmentRequest] ON");
                        context.RecruitmentRequest.AddRange(recruitmentRequests);
                        context.SaveChanges();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[RecruitmentRequest] OFF");
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            if (!context.RecruitmentRequestDetail.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var recruitmentRequestDetails = new List<RecruitmentRequestDetail>
                        {
                            new RecruitmentRequestDetail { Id = 1, RecruitmentRequestId = 1, JobTitleId = 1, Quantity = 5, RequiredSkills = "Giao tiếp tốt, Kỹ năng bán hàng", OptionalSkills = "Tiếng Anh" },
                            new RecruitmentRequestDetail { Id = 2, RecruitmentRequestId = 2, JobTitleId = 2, Quantity = 3, RequiredSkills = "Lập trình C#, JavaScript", OptionalSkills = "Kinh nghiệm làm việc với React" },
                            new RecruitmentRequestDetail { Id = 3, RecruitmentRequestId = 3, JobTitleId = 3, Quantity = 2, RequiredSkills = "Quản lý nhân sự, Kỹ năng giao tiếp", OptionalSkills = "Kinh nghiệm với phần mềm HRM" },
                            new RecruitmentRequestDetail { Id = 4, RecruitmentRequestId = 4, JobTitleId = 4, Quantity = 1, RequiredSkills = "Kế toán, Báo cáo tài chính", OptionalSkills = "Kinh nghiệm quản lý tài chính" },
                            new RecruitmentRequestDetail { Id = 5, RecruitmentRequestId = 5, JobTitleId = 5, Quantity = 4, RequiredSkills = "Lập kế hoạch marketing, SEO", OptionalSkills = "Kinh nghiệm với quảng cáo trực tuyến" }
                        }; 
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[RecruitmentRequestDetail] ON");
                        context.RecruitmentRequestDetail.AddRange(recruitmentRequestDetails);
                        context.SaveChanges();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[RecruitmentRequestDetail] OFF");
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            if (!context.Candidate.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var candidates = new List<Candidate>
                        {
                            new Candidate { Id = 1, RecruitmentRequestId = 1, JobTitleId = 1 },
                            new Candidate { Id = 2, RecruitmentRequestId = 2, JobTitleId = 2 },
                            new Candidate { Id = 3, RecruitmentRequestId = 3, JobTitleId = 3 },
                            new Candidate { Id = 4, RecruitmentRequestId = 4, JobTitleId = 4 },
                            new Candidate { Id = 5, RecruitmentRequestId = 5, JobTitleId = 5 },
                            new Candidate { Id = 6, RecruitmentRequestId = 1, JobTitleId = 2 },
                            new Candidate { Id = 7, RecruitmentRequestId = 2, JobTitleId = 3 },
                            new Candidate { Id = 8, RecruitmentRequestId = 3, JobTitleId = 4 },
                            new Candidate { Id = 9, RecruitmentRequestId = 4, JobTitleId = 5 },
                            new Candidate { Id = 10, RecruitmentRequestId = 5, JobTitleId = 1 }
                        };
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Candidate] ON");
                        context.Candidate.AddRange(candidates);
                        context.SaveChanges();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Candidate] OFF");
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            if (!context.Employee.Any())
            {
                using (var transaction = context.Database.BeginTransaction()) 
                {
                    try
                    {
                        var employees = new List<Employee>
                        {
                            new Employee
                            {
                                Id = 1,
                                FullName = "Nguyễn Văn A",
                                DoB = "1990-01-01",
                                PhoneNo = "0901234567",
                                Email = "nguyenvana@example.com",
                                ProvinceCode = "01",
                                DistrictCode = "001",
                                WardCode = "00001",
                                Address = "123 Đường ABC, Phường 1, Quận 1, Hà Nội",
                                EducationLevel = EducationLevel.University,
                                CandidateId = 1,
                                IsActive = true
                            },
                            new Employee
                            {
                                Id = 2,
                                FullName = "Trần Thị B",
                                DoB = "1992-05-12",
                                PhoneNo = "0912345678",
                                Email = "tranthib@example.com",
                                ProvinceCode = "01",
                                DistrictCode = "001",
                                WardCode = "00001",
                                Address = "456 Đường DEF, Phường 2, Quận 3, TP.HCM",
                                EducationLevel = EducationLevel.College,
                                CandidateId = 2,
                                IsActive = true
                            },
                            new Employee
                            {
                                Id = 3,
                                FullName = "Lê Văn C",
                                DoB = "1985-11-23",
                                PhoneNo = "0923456789",
                                Email = "levanc@example.com",
                                ProvinceCode = "01",
                                DistrictCode = "001",
                                WardCode = "00001",
                                Address = "789 Đường GHI, Phường 3, Quận 5, Đà Nẵng",
                                EducationLevel = EducationLevel.Intermediate,
                                CandidateId = 3,
                                IsActive = true
                            },
                            new Employee
                            {
                                Id = 4,
                                FullName = "Phạm Thị D",
                                DoB = "1988-03-14",
                                PhoneNo = "0934567890",
                                Email = "phamthid@example.com",
                                ProvinceCode = "01",
                                DistrictCode = "001",
                                WardCode = "00001",
                                Address = "101 Đường JKL, Phường 4, Quận 7, Cần Thơ",
                                EducationLevel = EducationLevel.Basic,
                                CandidateId = 4,
                                IsActive = true
                            },
                            new Employee
                            {
                                Id = 5,
                                FullName = "Hoàng Văn E",
                                DoB = "1995-07-30",
                                PhoneNo = "0945678901",
                                Email = "hoangvane@example.com",
                                ProvinceCode = "01",
                                DistrictCode = "001",
                                WardCode = "00001",
                                Address = "202 Đường MNO, Phường 5, Quận 8, Hải Phòng",
                                EducationLevel = EducationLevel.University,
                                CandidateId = 5,
                                IsActive = true
                            },
                            new Employee
                            {
                                Id = 6,
                                FullName = "Đinh Thị F",
                                DoB = "1991-09-15",
                                PhoneNo = "0956789012",
                                Email = "dinhthif@example.com",
                                ProvinceCode = "01",
                                DistrictCode = "001",
                                WardCode = "00001",
                                Address = "303 Đường PQR, Phường 6, Quận 9, Quảng Ninh",
                                EducationLevel = EducationLevel.College,
                                CandidateId = 6,
                                IsActive = true
                            },
                            new Employee
                            {
                                Id = 7,
                                FullName = "Vũ Văn G",
                                DoB = "1987-12-21",
                                PhoneNo = "0967890123",
                                Email = "vuvang@example.com",
                                ProvinceCode = "01",
                                DistrictCode = "001",
                                WardCode = "00001",
                                Address = "404 Đường STU, Phường 7, Quận 10, Thanh Hóa",
                                EducationLevel = EducationLevel.Intermediate,
                                CandidateId = 7,
                                IsActive = true
                            },
                            new Employee
                            {
                                Id = 8,
                                FullName = "Ngô Thị H",
                                DoB = "1993-02-11",
                                PhoneNo = "0978901234",
                                Email = "ngothih@example.com",
                                ProvinceCode = "01",
                                DistrictCode = "001",
                                WardCode = "00001",
                                Address = "505 Đường VWX, Phường 8, Quận 11, Khánh Hòa",
                                EducationLevel = EducationLevel.Basic,
                                CandidateId = 8,
                                IsActive = true
                            },
                            new Employee
                            {
                                Id = 9,
                                FullName = "Phùng Văn I",
                                DoB = "1996-04-07",
                                PhoneNo = "0989012345",
                                Email = "phungvani@example.com",
                                ProvinceCode = "01",
                                DistrictCode = "001",
                                WardCode = "00001",
                                Address = "606 Đường YZ, Phường 9, Quận 12, An Giang",
                                EducationLevel = EducationLevel.University,
                                CandidateId = 9,
                                IsActive = true
                            },
                            new Employee
                            {
                                Id = 10,
                                FullName = "Đỗ Thị J",
                                DoB = "1994-06-18",
                                PhoneNo = "0990123456",
                                Email = "dothij@example.com",
                                ProvinceCode = "01",
                                DistrictCode = "001",
                                WardCode = "00001",
                                Address = "707 Đường ABC, Phường 10, Quận 13, Bình Dương",
                                EducationLevel = EducationLevel.College,
                                CandidateId = 10,
                                IsActive = true
                            }
                        };
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Employee] ON");
                        context.Employee.AddRange(employees);
                        context.SaveChanges();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Employee] OFF");
                        transaction.Commit();
                    }
                    catch (Exception) 
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            if (!context.Contract.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var contracts = new List<Contract>
                        {
                            new Contract
                            {
                                Id = 1,
                                EmployeeId = 1,
                                EmployeeContractType = EmployeeContractType.FixedTerm,
                                FromDate = new DateTime(2024, 1, 1),
                                ToDate = new DateTime(2025, 1, 1),
                                BaseSalary = 1000m,
                                PerformanceSalary = 200m,
                                DepartmentId = 1,
                                SubjectId = 1,
                                PositionId = 1
                            },
                            new Contract
                            {
                                Id = 2,
                                EmployeeId = 2,
                                EmployeeContractType = EmployeeContractType.LongTerm,
                                FromDate = new DateTime(2024, 2, 1),
                                ToDate = new DateTime(2027, 2, 1),
                                BaseSalary = 1200m,
                                PerformanceSalary = 250m,
                                DepartmentId = 2,
                                SubjectId = 2,
                                PositionId = 2
                            },
                            new Contract
                            {
                                Id = 3,
                                EmployeeId = 3,
                                EmployeeContractType = EmployeeContractType.Probationary,
                                FromDate = new DateTime(2024, 3, 1),
                                ToDate = new DateTime(2024, 9, 1),
                                BaseSalary = 800m,
                                PerformanceSalary = 150m,
                                DepartmentId = 3,
                                SubjectId = 3,
                                PositionId = 3
                            },
                            new Contract
                            {
                                Id = 4,
                                EmployeeId = 4,
                                EmployeeContractType = EmployeeContractType.CollaboratorFullTime,
                                FromDate = new DateTime(2024, 4, 1),
                                ToDate = new DateTime(2024, 10, 1),
                                BaseSalary = 700m,
                                PerformanceSalary = 100m,
                                DepartmentId = 4,
                                SubjectId = 4,
                                PositionId = 4
                            },
                            new Contract
                            {
                                Id = 5,
                                EmployeeId = 5,
                                EmployeeContractType = EmployeeContractType.CollaboratorPartTime,
                                FromDate = new DateTime(2024, 5, 1),
                                ToDate = new DateTime(2024, 11, 1),
                                BaseSalary = 600m,
                                PerformanceSalary = 80m,
                                DepartmentId = 5,
                                SubjectId = 5,
                                PositionId = 5
                            },
                            new Contract
                            {
                                Id = 6,
                                EmployeeId = 6,
                                EmployeeContractType = EmployeeContractType.FixedTerm,
                                FromDate = new DateTime(2024, 6, 1),
                                ToDate = new DateTime(2025, 6, 1),
                                BaseSalary = 1100m,
                                PerformanceSalary = 220m,
                                DepartmentId = 1,
                                SubjectId = 1,
                                PositionId = 1
                            },
                            new Contract
                            {
                                Id = 7,
                                EmployeeId = 7,
                                EmployeeContractType = EmployeeContractType.LongTerm,
                                FromDate = new DateTime(2024, 7, 1),
                                ToDate = new DateTime(2027, 7, 1),
                                BaseSalary = 1300m,
                                PerformanceSalary = 270m,
                                DepartmentId = 2,
                                SubjectId = 2,
                                PositionId = 2
                            },
                            new Contract
                            {
                                Id = 8,
                                EmployeeId = 8,
                                EmployeeContractType = EmployeeContractType.Probationary,
                                FromDate = new DateTime(2024, 8, 1),
                                ToDate = new DateTime(2025, 2, 1),
                                BaseSalary = 900m,
                                PerformanceSalary = 180m,
                                DepartmentId = 3,
                                SubjectId = 3,
                                PositionId = 3
                            },
                            new Contract
                            {
                                Id = 9,
                                EmployeeId = 9,
                                EmployeeContractType = EmployeeContractType.CollaboratorFullTime,
                                FromDate = new DateTime(2024, 9, 1),
                                ToDate = new DateTime(2024, 12, 1),
                                BaseSalary = 750m,
                                PerformanceSalary = 120m,
                                DepartmentId = 4,
                                SubjectId = 4,
                                PositionId = 4
                            },
                            new Contract
                            {
                                Id = 10,
                                EmployeeId = 10,
                                EmployeeContractType = EmployeeContractType.CollaboratorPartTime,
                                FromDate = new DateTime(2024, 10, 1),
                                ToDate = new DateTime(2025, 4, 1),
                                BaseSalary = 650m,
                                PerformanceSalary = 90m,
                                DepartmentId = 5,
                                SubjectId = 5,
                                PositionId = 5
                            }
                        };
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Contract] ON");
                        context.Contract.AddRange(contracts);
                        context.SaveChanges();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Contract] OFF");
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            if(!context.Allowance.Any())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var allowances = new List<Allowance>
                        {
                            new Allowance
                            {
                                Id = 1,
                                Name = "Housing Allowance",
                                Description = "Monthly allowance for housing expenses."
                            },
                            new Allowance
                            {
                                Id = 2,
                                Name = "Transport Allowance",
                                Description = "Allowance provided for transportation costs."
                            },
                            new Allowance
                            {
                                Id = 3,
                                Name = "Medical Allowance",
                                Description = "Allowance for covering medical expenses."
                            },
                            new Allowance
                            {
                                Id = 4,
                                Name = "Meal Allowance",
                                Description = "Daily allowance for meal expenses."
                            },
                            new Allowance
                            {
                                Id = 5,
                                Name = "Communication Allowance",
                                Description = "Monthly allowance for phone and internet bills."
                            },
                            new Allowance
                            {
                                Id = 6,
                                Name = "Education Allowance",
                                Description = "Allowance for educational expenses of employees."
                            },
                            new Allowance
                            {
                                Id = 7,
                                Name = "Special Duty Allowance",
                                Description = "Allowance for employees on special duties."
                            },
                            new Allowance
                            {
                                Id = 8,
                                Name = "Uniform Allowance",
                                Description = "Allowance for purchasing uniforms."
                            },
                            new Allowance
                            {
                                Id = 9,
                                Name = "Leave Travel Allowance",
                                Description = "Allowance for travel during leave."
                            },
                            new Allowance
                            {
                                Id = 10,
                                Name = "Overtime Allowance",
                                Description = "Compensation for working overtime."
                            }
                        };
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Allowance] ON");
                        context.Allowance.AddRange(allowances);
                        context.SaveChanges();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Allowance] OFF");
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }    

        }
    }
}
