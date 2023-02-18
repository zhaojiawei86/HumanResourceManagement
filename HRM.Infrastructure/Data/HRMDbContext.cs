using System;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure.Data
{
	public class HRMDbContext : DbContext
	{
		public HRMDbContext(DbContextOptions<HRMDbContext> options) : base(options)
		{
		}
	}
}

