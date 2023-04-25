using System.ComponentModel.DataAnnotations;

namespace HotelSMIT.Data.Models
{
	public class HotelRoom
	{
		public int Id { get; set; }

		public int RoomNumber { get; set; }

		[Range(1,3)]
		public int BedCount { get; set; }

		public decimal Price { get; set; }

		public bool Enabled { get; set; }
	}
}
