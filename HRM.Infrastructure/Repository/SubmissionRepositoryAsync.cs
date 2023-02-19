using System;
using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Entity;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
	public class SubmissionRepositoryAsync : BaseRepositoryAsync<Submission>, ISubmissionRepositoryAsync
    {
        public SubmissionRepositoryAsync(HRMDbContext _context) : base(_context)
        {
        }
    }
}

