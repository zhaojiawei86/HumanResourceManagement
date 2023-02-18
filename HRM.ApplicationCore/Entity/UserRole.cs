﻿using System;
namespace HRM.ApplicationCore.Entity
{
	public class UserRole
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int RoleId { get; set; }

		// navi props
		public User User { get; set; }
		public Role Role { get; set; }
	}
}

