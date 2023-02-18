using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApplicationCore.Entity
{
	public class JobRequirement
	{
		public int Id { get; set; }
		[Required]
		[Column(TypeName ="varchar(100)")]
		public string Title { get; set; }
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string JobLocation { get; set; }
		public int NoOfPosition { get; set; }
		public DateTime PostingDate { get; set; }
		public DateTime ClosingDate { get; set; }
		public bool IsActive { get; set; }
        [Required]
        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }
		public int JobCategoryId { get; set; }

		// navigational propertis
		public JobCategory JobCategory { get; set; }
	}
}

