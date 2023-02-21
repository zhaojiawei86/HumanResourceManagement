using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.ApplicationCore.Model.Response
{
	public class FeedbackResponseModel
	{
        public int Id { get; set; }
        public int InterviewId { get; set; }
        public string Description { get; set; }
    }
}

