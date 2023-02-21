using System;
namespace HRM.ApplicationCore.Model.Request
{
	public class InterviewRequestModel
	{
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public DateTime InterviewDate { get; set; }
        public int InterviewRound { get; set; }
        public int InterviewTypeId { get; set; }
        public int InterviewStatusId { get; set; }
        public int InterviewerId { get; set; }

    }
}

