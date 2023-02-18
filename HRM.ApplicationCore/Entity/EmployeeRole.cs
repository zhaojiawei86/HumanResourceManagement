using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApplicationCore.Entity
{
	public class EmployeeRole
	{
		public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string description { get; set; }
		public bool IsActive { get; set; }
	}
}

