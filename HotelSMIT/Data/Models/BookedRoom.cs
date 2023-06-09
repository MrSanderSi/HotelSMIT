﻿using HotelSMIT.Data.Constants;

namespace HotelSMIT.Data.Models
{
	public class BookedRoom
	{
		public int Id { get; set; }

		public User User { get; set; }

		public HotelRoom Room { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public DateTime Offset => StartDate.AddDays(-SystemConstants.BookingCutoffInDays);
	}
}
