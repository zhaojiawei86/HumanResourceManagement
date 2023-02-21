using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.ApplicationCore.Model.Response
{
	public class EmployeeStatusResponseModel
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string? description { get; set; }
        public bool IsActive { get; set; }
    }
}

