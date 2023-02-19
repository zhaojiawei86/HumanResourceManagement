using System;
using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Entity;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
	public class RoleRepositoryAsync : BaseRepositoryAsync<Role>, IRoleRepositoryAsync
    {
        public RoleRepositoryAsync(HRMDbContext _context) : base(_context)
        {
        }
    }
}

