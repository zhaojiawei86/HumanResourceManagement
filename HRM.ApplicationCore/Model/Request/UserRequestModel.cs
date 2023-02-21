using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApplicationCore.Model.Request
{
	public class UserRequestModel
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "EmailId is required")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}

