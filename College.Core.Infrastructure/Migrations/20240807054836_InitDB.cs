using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace College.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdministrativeRegion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeRegion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdministrativeUnit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Allowance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allowance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Benefit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfCredits = table.Column<int>(type: "int", nullable: false),
                    NumberOfLessons = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Department_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EducationYear",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromYear = table.Column<int>(type: "int", nullable: false),
                    ToYear = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationYear", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTitle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeetingRoom",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecruitmentRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitmentRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkShift",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministrativeUnitId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministrativeUnitId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Code);
                    table.ForeignKey(
                        name: "FK_District_AdministrativeUnit_AdministrativeUnitId1",
                        column: x => x.AdministrativeUnitId1,
                        principalTable: "AdministrativeUnit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministrativeUnitId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministrativeUnitId1 = table.Column<long>(type: "bigint", nullable: true),
                    AdministrativeRegionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministrativeRegionId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Province_AdministrativeRegion_AdministrativeRegionId1",
                        column: x => x.AdministrativeRegionId1,
                        principalTable: "AdministrativeRegion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Province_AdministrativeUnit_AdministrativeUnitId1",
                        column: x => x.AdministrativeUnitId1,
                        principalTable: "AdministrativeUnit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseCondition",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    RequiredCourseId = table.Column<long>(type: "bigint", nullable: true),
                    RequiredMinNumOfCredit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseCondition_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseCondition_Course_RequiredCourseId",
                        column: x => x.RequiredCourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseDepartment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EducationMasterPlan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationYearId = table.Column<long>(type: "bigint", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterPlanType = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationMasterPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationMasterPlan_EducationYear_EducationYearId",
                        column: x => x.EducationYearId,
                        principalTable: "EducationYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RecruitmentRequestDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecruitmentRequestId = table.Column<long>(type: "bigint", nullable: false),
                    JobTitleId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    RequiredSkills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionalSkills = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitmentRequestDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecruitmentRequestDetail_JobTitle_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RecruitmentRequestDetail_RecruitmentRequest_RecruitmentRequestId",
                        column: x => x.RecruitmentRequestId,
                        principalTable: "RecruitmentRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Ward_District_DistrictCode",
                        column: x => x.DistrictCode,
                        principalTable: "District",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "CourseSubject",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    SubjectId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSubject_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CourseClass",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationMasterPlanId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseClass_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseClass_EducationMasterPlan_EducationMasterPlanId",
                        column: x => x.EducationMasterPlanId,
                        principalTable: "EducationMasterPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecruitmentRequestId = table.Column<long>(type: "bigint", nullable: false),
                    JobTitleId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DistrictCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WardCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidate_District_DistrictCode",
                        column: x => x.DistrictCode,
                        principalTable: "District",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Candidate_JobTitle_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Candidate_Province_ProvinceCode",
                        column: x => x.ProvinceCode,
                        principalTable: "Province",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Candidate_RecruitmentRequest_RecruitmentRequestId",
                        column: x => x.RecruitmentRequestId,
                        principalTable: "RecruitmentRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Candidate_Ward_WardCode",
                        column: x => x.WardCode,
                        principalTable: "Ward",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "EducationProcess",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<long>(type: "bigint", nullable: true),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraduatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GraduatedPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationProcess_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DistrictCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WardCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_District_DistrictCode",
                        column: x => x.DistrictCode,
                        principalTable: "District",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Employee_Province_ProvinceCode",
                        column: x => x.ProvinceCode,
                        principalTable: "Province",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Employee_Ward_WardCode",
                        column: x => x.WardCode,
                        principalTable: "Ward",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "Interview",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<long>(type: "bigint", nullable: false),
                    InterviewResult = table.Column<int>(type: "int", nullable: false),
                    ResultDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeetingRoomId = table.Column<long>(type: "bigint", nullable: false),
                    OnBoardDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interview_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Interview_MeetingRoom_MeetingRoomId",
                        column: x => x.MeetingRoomId,
                        principalTable: "MeetingRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeContractType = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PerformanceSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeparmentId = table.Column<long>(type: "bigint", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    SubjectId = table.Column<long>(type: "bigint", nullable: false),
                    PositionId = table.Column<long>(type: "bigint", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contract_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Contract_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Contract_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalary",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsuranceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PerformanceSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LecturerAssignment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationMasterPlanId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturerAssignment_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LecturerAssignment_EducationMasterPlan_EducationMasterPlanId",
                        column: x => x.EducationMasterPlanId,
                        principalTable: "EducationMasterPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LecturerAssignment_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ContractAllowance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<long>(type: "bigint", nullable: false),
                    AllowanceId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractAllowance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractAllowance_Allowance_AllowanceId",
                        column: x => x.AllowanceId,
                        principalTable: "Allowance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContractAllowance_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ContractBenefit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<long>(type: "bigint", nullable: false),
                    BenefitId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractBenefit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractBenefit_Benefit_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ContractBenefit_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LecturerAssignmentSchedule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerAssignmentId = table.Column<long>(type: "bigint", nullable: false),
                    CourseClassId = table.Column<long>(type: "bigint", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    FromLessonPeriod = table.Column<int>(type: "int", nullable: false),
                    ToLessonPeriod = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerAssignmentSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturerAssignmentSchedule_CourseClass_CourseClassId",
                        column: x => x.CourseClassId,
                        principalTable: "CourseClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LecturerAssignmentSchedule_LecturerAssignment_LecturerAssignmentId",
                        column: x => x.LecturerAssignmentId,
                        principalTable: "LecturerAssignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_DistrictCode",
                table: "Candidate",
                column: "DistrictCode");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_JobTitleId",
                table: "Candidate",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_ProvinceCode",
                table: "Candidate",
                column: "ProvinceCode");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_RecruitmentRequestId",
                table: "Candidate",
                column: "RecruitmentRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_WardCode",
                table: "Candidate",
                column: "WardCode");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_DepartmentId",
                table: "Contract",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_EmployeeId",
                table: "Contract",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_PositionId",
                table: "Contract",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_SubjectId",
                table: "Contract",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractAllowance_AllowanceId",
                table: "ContractAllowance",
                column: "AllowanceId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractAllowance_ContractId",
                table: "ContractAllowance",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractBenefit_BenefitId",
                table: "ContractBenefit",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractBenefit_ContractId",
                table: "ContractBenefit",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseClass_CourseId",
                table: "CourseClass",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseClass_EducationMasterPlanId",
                table: "CourseClass",
                column: "EducationMasterPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCondition_CourseId",
                table: "CourseCondition",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseCondition_RequiredCourseId",
                table: "CourseCondition",
                column: "RequiredCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDepartment_CourseId",
                table: "CourseDepartment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDepartment_DepartmentId",
                table: "CourseDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubject_CourseId",
                table: "CourseSubject",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubject_SubjectId",
                table: "CourseSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_ParentId",
                table: "Department",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_District_AdministrativeUnitId1",
                table: "District",
                column: "AdministrativeUnitId1");

            migrationBuilder.CreateIndex(
                name: "IX_EducationMasterPlan_EducationYearId",
                table: "EducationMasterPlan",
                column: "EducationYearId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationProcess_CandidateId",
                table: "EducationProcess",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CandidateId",
                table: "Employee",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DistrictCode",
                table: "Employee",
                column: "DistrictCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ProvinceCode",
                table: "Employee",
                column: "ProvinceCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_WardCode",
                table: "Employee",
                column: "WardCode");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_EmployeeId",
                table: "EmployeeSalary",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_CandidateId",
                table: "Interview",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_MeetingRoomId",
                table: "Interview",
                column: "MeetingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerAssignment_CourseId",
                table: "LecturerAssignment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerAssignment_EducationMasterPlanId",
                table: "LecturerAssignment",
                column: "EducationMasterPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerAssignment_EmployeeId",
                table: "LecturerAssignment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerAssignmentSchedule_CourseClassId",
                table: "LecturerAssignmentSchedule",
                column: "CourseClassId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerAssignmentSchedule_LecturerAssignmentId",
                table: "LecturerAssignmentSchedule",
                column: "LecturerAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Province_AdministrativeRegionId1",
                table: "Province",
                column: "AdministrativeRegionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Province_AdministrativeUnitId1",
                table: "Province",
                column: "AdministrativeUnitId1");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentRequestDetail_JobTitleId",
                table: "RecruitmentRequestDetail",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentRequestDetail_RecruitmentRequestId",
                table: "RecruitmentRequestDetail",
                column: "RecruitmentRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_DepartmentId",
                table: "Subject",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Ward_DistrictCode",
                table: "Ward",
                column: "DistrictCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractAllowance");

            migrationBuilder.DropTable(
                name: "ContractBenefit");

            migrationBuilder.DropTable(
                name: "CourseCondition");

            migrationBuilder.DropTable(
                name: "CourseDepartment");

            migrationBuilder.DropTable(
                name: "CourseSubject");

            migrationBuilder.DropTable(
                name: "EducationProcess");

            migrationBuilder.DropTable(
                name: "EmployeeSalary");

            migrationBuilder.DropTable(
                name: "Interview");

            migrationBuilder.DropTable(
                name: "LecturerAssignmentSchedule");

            migrationBuilder.DropTable(
                name: "RecruitmentRequestDetail");

            migrationBuilder.DropTable(
                name: "RequestType");

            migrationBuilder.DropTable(
                name: "WorkShift");

            migrationBuilder.DropTable(
                name: "Allowance");

            migrationBuilder.DropTable(
                name: "Benefit");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "MeetingRoom");

            migrationBuilder.DropTable(
                name: "CourseClass");

            migrationBuilder.DropTable(
                name: "LecturerAssignment");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "EducationMasterPlan");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "EducationYear");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "JobTitle");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "RecruitmentRequest");

            migrationBuilder.DropTable(
                name: "Ward");

            migrationBuilder.DropTable(
                name: "AdministrativeRegion");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "AdministrativeUnit");
        }
    }
}
