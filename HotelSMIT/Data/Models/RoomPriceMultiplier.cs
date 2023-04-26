using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelSMIT.Data.Models
{
	public class RoomPriceMultiplier
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		int Id { get; set; }

		public decimal Multiplier { get; set; } = 1.00M;
	}
}
