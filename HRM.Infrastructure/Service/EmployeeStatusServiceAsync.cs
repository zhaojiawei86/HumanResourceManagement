using System;
using System.ComponentModel.DataAnnotations;
using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Entity;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;

namespace HRM.Infrastructure.Service
{
	public class EmployeeStatusServiceAsync : IEmployeeStatusServiceAsync
    {
        private readonly IEmployeeStatusRepositoryAsync employeeStatusRepositoryAsync;

        public EmployeeStatusServiceAsync(IEmployeeStatusRepositoryAsync _employeeStatusRepositoryAsync)
		{
            employeeStatusRepositoryAsync = _employeeStatusRepositoryAsync;
        }

        // async for insert is not necessory, speed up
        public Task<int> AddAsync(EmployeeStatusRequestModel model)
        {
            EmployeeStatus employeeStatus = new EmployeeStatus()
            {
                Title = model.Title,
                description = model.description,
                IsActive = model.IsActive
            };
            return employeeStatusRepositoryAsync.InsertAsync(employeeStatus);
        }

        public Task<int> DeleteAsync(int id)
        {
            return employeeStatusRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeStatusResponseModel>> GetAllAsync()
        {
            var result = await employeeStatusRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new EmployeeStatusResponseModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    description = x.description,
                    IsActive = x.IsActive
                });
            }
            return null;
            
        }

        public async Task<EmployeeStatusResponseModel> GetByIdAsync(int id)
        {
            var result = await employeeStatusRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new EmployeeStatusResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    description = result.description,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public async Task<int> UpdateAsync(EmployeeStatusRequestModel model)
        {
            EmployeeStatus employeeStatus = new EmployeeStatus()
            {
                Id = model.Id,
                Title = model.Title,
                description = model.description,
                IsActive = model.IsActive
            };
            return await employeeStatusRepositoryAsync.UpdateAsync(employeeStatus);
        }
    }
}

