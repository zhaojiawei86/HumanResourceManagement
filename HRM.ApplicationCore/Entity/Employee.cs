﻿using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApplicationCore.Entity
{
	public class Employee
	{
		public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(70)")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime DOB { get; set; }
		[Required]
        [Column(TypeName = "varchar(20)")]
        public string SSN { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string CurrentAddress { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
		public int EmployeeRoleId { get; set; }
		public int EmployeeTypeId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
		public int EmployeeStatusId { get; set; }
		public int ManagerId { get; set; }

		// navi props
        public EmployeeRole EmployeeRole { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
    }
}

