using College.Core.Business;
using College.Core.Entities;
using College.Core.Infrastructure;
using College.Core.Models;
using College.Core.Models.RequestModels;
using College.Core.Models.ResponseModels.Contract;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using static College.Commons.CommonEnums;
using static System.Net.Mime.MediaTypeNames;
using Contract = College.Core.Entities.Contract;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;

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
                    .Where(record => !record.IsDeleted && record.DepartmentId == departmentId)
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
        public async Task<List<FillDropPosition>> FillDropDowPosition()
        {
            var result = _context.Position
                        .Where(record => !record.IsDeleted)
                        .Select(record => new FillDropPosition()
                        {
                            Id = record.Id,
                            Name = record.Name,
                        })
                        .ToList();
            return result;
        }

        //Xóa hợp đồng
        public async Task<bool> DeteleContract(long contractId)
        {
            if(contractId == 0)
            {
                return false;
            }
            try
            {
                var contractData = _context.Contract.Where(contract => contract.Id == contractId)
                                    .FirstOrDefault();

                if(contractData == null || contractData.IsDeleted == true)
                {
                    return false;
                }    

                contractData.IsDeleted = true;
                _context.Contract.Update(contractData);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
            return true;
        }
        public string ExportContract(long contractId)
        {

            string SampleContract = "D:\\Word\\HopDong_Mau.docx";
            string outputPath = "D:\\Word\\output_contract.docx";

            var contractData = _context.Contract
                                    .Where(contract => contract.Id == contractId)
                                    .Select(contract => new RequestExportContract()
                                    {
                                        id = contract.Id,
                                        name = contract.Employee.FullName,
                                        contractType = contract.EmployeeContractType,
                                        position = contract.Position.Name,
                                        Departments = contract.Department.Name,
                                        FromDate = contract.FromDate.Date.ToString(),
                                        ToDate = contract.ToDate.Date.ToString(),
                                    })
                                    .FirstOrDefault();
                                                
            System.IO.File.Copy(SampleContract, outputPath, true);
            using (WordprocessingDocument doc = WordprocessingDocument.Open(outputPath, true))
            {
                var body = doc.MainDocumentPart.Document.Body;
                foreach (var text in body.Descendants<Text>())
                {
                    text.Text = text.Text.Replace("{name}", contractData.name)
                                         .Replace("{position}", contractData.position)
                                         .Replace("{contractType}", contractData.contractType.ToString())
                                         .Replace("{departments}", contractData.Departments)
                                         .Replace("{StartDate}", contractData.FromDate)
                                         .Replace("{EndDate}", contractData.ToDate);
                }
                doc.MainDocumentPart.Document.Save();
            }
            return outputPath;
        }

        public async Task<bool> CreateEditContracts(CreateEditContractRequestModel input)
        {
            try
            {
                Contract contract;
                if (input.Id <= 0)
                {
                    contract = new Contract
                    {
                        EmployeeId = input.EmployeeId,
                        DepartmentId = input.DepartmentId,
                        PositionId = input.PositionId,
                        EmployeeContractType = input.employeeContractType,
                        BaseSalary = input.BaseSalary,
                        PerformanceSalary = input.PerformanceSalary,
                        SubjectId = input.SubjectId,
                        FromDate = input.FromDate,
                        ToDate = input.ToDate
                    };
                    _context.Contract.Add(contract);
                    await _context.SaveChangesAsync();
                        if (input.Allowances != null && input.Allowances.Any())
                        {
                            var contractAllowances = input.Allowances.Select(a => new ContractAllowance
                            {
                                ContractId = contract.Id, // Sử dụng ContractId vừa được tạo
                                AllowanceId = a.AllowanceId,
                                Amount = a.Amount,
                                FromDate = a.FromDate,
                                ToDate = a.ToDate
                            }).ToList();

                            _context.ContractAllowance.AddRange(contractAllowances);
                            await _context.SaveChangesAsync();
                        }
                    else
                    {
                        contract = _context.Contract
                            /*.Include(contract => contract.ContractAllowances)*/
                            .Where(record => record.Id == input.Id && record.IsDeleted == false).FirstOrDefault();
                        if (contract == null)
                        {
                            return false;
                        }

                        _context.Contract.Update(contract);
                    }
                    await _context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLineAsync(ex.ToString());
                return false;
            }
            return true;
        }
    }
}
