using System;
using System.ComponentModel.DataAnnotations;
using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Entity;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using HRM.Infrastructure.Repository;

namespace HRM.Infrastructure.Service
{
	public class RoleServiceAsync : IRoleServiceAsync
	{
        private readonly IRoleRepositoryAsync roleRepositoryAsync;

        public RoleServiceAsync(IRoleRepositoryAsync _roleRepositoryAsync)
		{
            roleRepositoryAsync = _roleRepositoryAsync;
        }

        // async for insert is not necessory, speed up
        public Task<int> AddAsync(RoleRequestModel model)
        {
            Role role = new Role()
            {
                Name = model.Name,
                Description = model.Description   
            };
            return roleRepositoryAsync.InsertAsync(role);
        }

        public Task<int> DeleteAsync(int id)
        {
            return roleRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<RoleResponseModel>> GetAllAsync()
        {
            var result = await roleRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new RoleResponseModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                });
            }
            return null;
            
        }

        public async Task<RoleResponseModel> GetByIdAsync(int id)
        {
            var result = await roleRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new RoleResponseModel()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Description = result.Description
                };
            }
            return null;
        }

        public async Task<int> UpdateAsync(RoleRequestModel model)
        {
            Role role = new Role()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };
            return await roleRepositoryAsync.UpdateAsync(role);
        }
    }
}

