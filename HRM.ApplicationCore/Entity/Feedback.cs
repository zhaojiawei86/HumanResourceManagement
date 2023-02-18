using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApplicationCore.Entity
{
	public class Feedback
	{
		public int Id { get; set; }
		public int InterviewId { get; set; }
        [Required]
        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }

		// navi props
		public Interview Interview { get; set; }
	}
}

