using System;
using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Entity;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
    public class EmployeeStatusRepositoryAsync : BaseRepositoryAsync<EmployeeStatus>, IEmployeeStatusRepositoryAsync
    {
        public EmployeeStatusRepositoryAsync(HRMDbContext _context) : base(_context)
        {
        }
    }
}
