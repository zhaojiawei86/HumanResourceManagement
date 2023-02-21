using System;
namespace HRM.ApplicationCore.Model.Response
{
	public class SubmissionResponseModel
	{
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int JobRequirementId { get; set; }
        public DateTime AppliedDate { get; set; }
    }
}

