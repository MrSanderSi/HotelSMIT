using System.ComponentModel.DataAnnotations;

namespace HotelSMIT.UI.Models
{
	public class RoomModel
	{
		[Required]
		[Range(1,800)]
		public int RoomNumber { get; set; }

		[Required]
		[Range(1,3)]
		public int BedCount { get; set; }

		[Required]
		public decimal Price { get; set; }
	}
}
