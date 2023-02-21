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
    public class UserRoleServiceAsync : IUserRoleServiceAsync
    {
        private readonly IUserRoleRepositoryAsync userRoleRepositoryAsync;

        public UserRoleServiceAsync(IUserRoleRepositoryAsync _userRoleRepositoryAsync)
        {
            userRoleRepositoryAsync = _userRoleRepositoryAsync;
        }

        // async for insert is not necessory, speed up
        public Task<int> AddAsync(UserRoleRequestModel model)
        {
            UserRole userRole = new UserRole()
            {
                UserId = model.UserId,
                RoleId = model.RoleId
    };
            return userRoleRepositoryAsync.InsertAsync(userRole);
        }

        public Task<int> DeleteAsync(int id)
        {
            return userRoleRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserRoleResponseModel>> GetAllAsync()
        {
            var result = await userRoleRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new UserRoleResponseModel()
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    RoleId = x.RoleId
                });
            }
            return null;

        }

        public async Task<UserRoleResponseModel> GetByIdAsync(int id)
        {
            var result = await userRoleRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new UserRoleResponseModel()
                {
                    Id = result.Id,
                    UserId = result.UserId,
                    RoleId = result.RoleId
                };
            }
            return null;
        }

        public async Task<int> UpdateAsync(UserRoleRequestModel model)
        {
            UserRole userRole = new UserRole()
            {
                Id = model.Id,
                UserId = model.UserId,
                RoleId = model.RoleId
            };
            return await userRoleRepositoryAsync.UpdateAsync(userRole);
        }
    }
}
