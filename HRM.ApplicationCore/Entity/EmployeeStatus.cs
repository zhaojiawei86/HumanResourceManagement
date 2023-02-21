using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRM.ApplicationCore.Entity
{
	public class EmployeeStatus
	{
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string? description { get; set; }
        public bool IsActive { get; set; }
    }
}

