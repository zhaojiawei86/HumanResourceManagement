using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.ApplicationCore.Model.Request
{
	public class InterviewStatusRequestModel
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}

