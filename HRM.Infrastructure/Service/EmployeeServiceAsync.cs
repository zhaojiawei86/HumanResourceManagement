using System;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Entity;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;

namespace HRM.Infrastructure.Service
{
	public class EmployeeServiceAsync : IEmployeeServiceAsync
	{
        private readonly IEmployeeRepositoryAsync employeeRepositoryAsync;

        public EmployeeServiceAsync(IEmployeeRepositoryAsync _employeeRepositoryAsync)
		{
            employeeRepositoryAsync = _employeeRepositoryAsync;
        }

        public Task<int> AddAsync(EmployeeRequestModel model)
        {
            Employee emplyee = new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailId = model.EmailId,
                DOB = model.DOB,
                SSN = model.SSN,
                CurrentAddress = model.CurrentAddress,
                Phone = model.Phone,
                HireDate = model.HireDate,
                EmployeeRoleId = model.EmployeeRoleId,
                EmployeeTypeId = model.EmployeeTypeId,
                EndDate = model.EndDate,
                EmployeeStatusId = model.EmployeeStatusId,
                ManagerId = model.ManagerId
            };
            return employeeRepositoryAsync.InsertAsync(emplyee);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await employeeRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetAllAsync()
        {
            var result = await employeeRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(model => new EmployeeResponseModel
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailId = model.EmailId,
                    DOB = model.DOB,
                    SSN = model.SSN,
                    CurrentAddress = model.CurrentAddress,
                    Phone = model.Phone,
                    HireDate = model.HireDate,
                    EmployeeRoleId = model.EmployeeRoleId,
                    EmployeeTypeId = model.EmployeeTypeId,
                    EndDate = model.EndDate,
                    EmployeeStatusId = model.EmployeeStatusId,
                    ManagerId = model.ManagerId
                });
            }
            return null;
        }

        public async Task<EmployeeResponseModel> GetByIdAsync(int id)
        {
            var result = await employeeRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new EmployeeResponseModel()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    EmailId = result.EmailId,
                    DOB = result.DOB,
                    SSN = result.SSN,
                    CurrentAddress = result.CurrentAddress,
                    Phone = result.Phone,
                    HireDate = result.HireDate,
                    EmployeeRoleId = result.EmployeeRoleId,
                    EmployeeTypeId = result.EmployeeTypeId,
                    EndDate = result.EndDate,
                    EmployeeStatusId = result.EmployeeStatusId,
                    ManagerId = result.ManagerId
                };
            }
            return null;
        }

        public async Task<int> UpdateAsync(EmployeeRequestModel model)
        {
            Employee employee = new Employee()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailId = model.EmailId,
                DOB = model.DOB,
                SSN = model.SSN,
                CurrentAddress = model.CurrentAddress,
                Phone = model.Phone,
                HireDate = model.HireDate,
                EmployeeRoleId = model.EmployeeRoleId,
                EmployeeTypeId = model.EmployeeTypeId,
                EndDate = model.EndDate,
                EmployeeStatusId = model.EmployeeStatusId,
                ManagerId = model.ManagerId
            };
            return await employeeRepositoryAsync.UpdateAsync(employee);
        }
    }
}

