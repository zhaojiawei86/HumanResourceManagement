using System;
namespace HRM.ApplicationCore.Entity
{
	public class Submission
	{
		public int Id { get; set; }
		public int CandidateId { get; set; }
		public int JobRequirementId { get; set; }
		public DateTime AppliedDate { get; set; }

		// navi props
		public Candidate Candidate { get; set; }
		public JobRequirement JobRequirement { get; set; }
	}
}

