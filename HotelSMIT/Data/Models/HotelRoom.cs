using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelSMIT.Data.Models
{
	public class HotelRoom
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int RoomNumber { get; set; }

		[Range(1,3)]
		public int BedCount { get; set; }

		public decimal Price { get; set; }

		public bool Enabled { get; set; }
	}
}
