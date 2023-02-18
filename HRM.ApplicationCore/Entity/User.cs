using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApplicationCore.Entity
{
	public class User
	{
		public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName = "varchar(70)")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
	}
}

