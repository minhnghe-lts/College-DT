using College.Core.Business;
using College.Core.Entities;
using College.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using static College.Commons.CommonEnums;

namespace College.Core.Business
{
    public class ContractService : IContractService
    {
        private readonly AppDbContext _context;

        public ContractService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContractResponseModel>> ListContract()
        {
            try
            {
                var result = _context.Contract
                    .Where(record => !record.IsDeleted)
                    .Select(record => new ContractResponseModel {
                        Id = record.Id,
                        EmployeeContractType = record.EmployeeContractType,
                        EmployeeName = record.Employee.FullName,
                        PositionName = record.Position.Name,
                        DepartmentName = record.Department.Name,
                        FromDate = record.FromDate,
                        ToDate = record.ToDate,
                    })
                    .ToList();
                return result;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                throw;
            }
        }

        public async Task<List<ContractResponseModel>> FindContractByPositionId(long positionId)
        {
            try
            {
                var result = _context.Contract
                    .Where(record => !record.IsDeleted && record.PositionId == positionId)
                    .Select(record => new ContractResponseModel
                    {
                        Id = record.Id,
                        EmployeeContractType = record.EmployeeContractType,
                        EmployeeName = record.Employee.FullName,
                        PositionName = record.Position.Name,
                        DepartmentName = record.Department.Name,
                        FromDate = record.FromDate,
                        ToDate = record.ToDate,
                    })
                    .ToList();
                return result;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                throw;
            }
        }

        public async Task<List<ContractResponseModel>> FindContractByEmployeeContractType(EmployeeContractType contractType)
        {
            try
            {
                var result = _context.Contract
                    .Where(record => !record.IsDeleted && record.EmployeeContractType == contractType)
                    .Select(record => new ContractResponseModel
                    {
                        Id = record.Id,
                        EmployeeContractType = record.EmployeeContractType,
                        EmployeeName = record.Employee.FullName,
                        PositionName = record.Position.Name,
                        DepartmentName = record.Department.Name,
                        FromDate = record.FromDate,
                        ToDate = record.ToDate,
                    })
                    .ToList();
                return result;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                throw;
            }
        }

        public async Task<List<ContractResponseModel>> FindContractByDepartmentId(long departmentId)
        {
            try
            {
                var result = _context.Contract
                    .Where(record => !record.IsDeleted && record.DeparmentId == departmentId)
                    .Select(record => new ContractResponseModel
                    {
                        Id = record.Id,
                        EmployeeContractType = record.EmployeeContractType,
                        EmployeeName = record.Employee.FullName,
                        PositionName = record.Position.Name,
                        DepartmentName = record.Department.Name,
                        FromDate = record.FromDate,
                        ToDate = record.ToDate,
                    })
                    .ToList();
                return result;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                throw;
            }
        }

        public async Task<List<ContractResponseModel>> FindContractByDateRange(DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                var result = _context.Contract
                    .Where(record => !record.IsDeleted && record.FromDate == fromDate && record.ToDate == toDate)
                    .Select(record => new ContractResponseModel
                    {
                        Id = record.Id,
                        EmployeeContractType = record.EmployeeContractType,
                        EmployeeName = record.Employee.FullName,
                        PositionName = record.Position.Name,
                        DepartmentName = record.Department.Name,
                        FromDate = record.FromDate,
                        ToDate = record.ToDate,
                    })
                    .ToList();
                return result;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                throw;
            }
        }

        //public async Task CreateEditContracts(CreateEditContractRequestModel input)
        //{
        //    Contract contract;
        //    if (input.Id <= 0)
        //    {
        //        contract = new Contract
        //        {
        //            EmployeeId = input.EmployeeId,
        //            DeparmentId = input.DepartmentId,
        //            PositionId = input.PositionId,
        //            EmployeeContractType = input.employeeContractType,
        //            BaseSalary = input.BaseSalary,
        //            PerformanceSalary = input.PerformanceSalary,
        //            ContractAllowances = input.Allowances.Select(item => new ContractAllowance
        //            {
        //                AllowanceId = item.Id,
        //                FromDate = item.FromDate,
        //                ToDate = item.ToDate,
        //                Amount = item.Amount,
        //            }).ToList()
        //        };
        //        _context.Contract.Add(contract);
        //    }
        //    else
        //    {
        //        contract = _context.Contract
        //            .Include(contract => contract.ContractAllowances)
        //            .Where(record => record.Id == input.Id).FirstOrDefault();



        //        _context.Contract.Update(contract);
        //    }
        //    await _context.SaveChangesAsync();
        //}
    }

    public class CreateEditContractRequestModel
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public long PositionId { get; set; }
        public long DepartmentId { get; set; }
        public EmployeeContractType employeeContractType { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal PerformanceSalary { get; set; }
        public List<ContractAllowanceReqModel> Allowances { get; set; }
    }

    public class ContractAllowanceReqModel
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class ContractResponseModel
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public long PositionId { get; set; }
        public long DepartmentId { get; set; }
        public string EmployeeName { get; set; }
        public string PositionName { get; set; }
        public string DepartmentName { get; set; }
        public EmployeeContractType EmployeeContractType { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }


    }
}
