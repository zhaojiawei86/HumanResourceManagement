using System;
using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Entity;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
	public class UserRepositoryAsync : BaseRepositoryAsync<User>, IUserRepositoryAsync
    {
        public UserRepositoryAsync(HRMDbContext _context) : base(_context)
        {
        }
    }
}

