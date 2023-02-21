using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.ApplicationCore.Model.Response
{
	public class JobRequirmentResponseModel
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string JobLocation { get; set; }
        public int NoOfPosition { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public int JobCategoryId { get; set; }

    }
}

