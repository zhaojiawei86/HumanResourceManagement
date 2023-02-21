using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApplicationCore.Model.Request
{
	public class FeedbackRequestModel
	{
        public int Id { get; set; }
        public int InterviewId { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}

