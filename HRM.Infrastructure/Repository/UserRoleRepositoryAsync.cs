using System;
using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Entity;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
	public class UserRoleRepositoryAsync : BaseRepositoryAsync<UserRole>, IUserRoleRepositoryAsync
    {
        public UserRoleRepositoryAsync(HRMDbContext _context) : base(_context)
        {
        }
    }
}

