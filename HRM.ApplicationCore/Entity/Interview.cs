using System;
namespace HRM.ApplicationCore.Entity
{
	public class Interview
	{
		public int Id { get; set; }
		public int SubmissionId { get; set; }
		public DateTime InterviewDate { get; set; }
		public int InterviewRound { get; set; }
		public int InterviewTypeId { get; set; }
		public int InterviewStatusId { get; set; }
		public int InterviewerId { get; set; }

		// navi props
		public Submission Submission { get; set; }
		public InterviewType InterviewType { get; set; }
		public InterviewStatus InterviewStatus { get; set; }
		public Employee Interviewer { get; set; }
	}
}

