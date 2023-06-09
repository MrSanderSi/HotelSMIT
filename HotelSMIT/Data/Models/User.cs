﻿using System.ComponentModel.DataAnnotations;
using HotelSMIT.Data.Constants;

namespace HotelSMIT.Data.Models
{
	public class User
	{
		public int Id { get; set; }

		[MaxLength(MaxLenghtPolicy.StringMaxLength)]
		public string PersonalId { get; set; }

		[MaxLength(MaxLenghtPolicy.StringMaxLength)]
		public string FirstName { get; set; }

		[MaxLength(MaxLenghtPolicy.StringMaxLength)]
		public string LastName { get; set; }

		[MaxLength(MaxLenghtPolicy.StringMaxLength)]
		public string Email { get; set; }

		public bool IsAdmin { get; set; }
	}
}
