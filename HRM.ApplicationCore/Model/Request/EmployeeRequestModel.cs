using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApplicationCore.Model.Request
{
	public class EmployeeRequestModel
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "DOB is required")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "SSN is required")]
        public string SSN { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string CurrentAddress { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Hire Date is required")]
        public DateTime HireDate { get; set; }
        public int EmployeeRoleId { get; set; }
        public int EmployeeTypeId { get; set; }
        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }
        public int EmployeeStatusId { get; set; }
        public int ManagerId { get; set; }
    }
}

