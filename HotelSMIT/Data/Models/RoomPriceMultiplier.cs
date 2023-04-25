namespace HotelSMIT.Data.Models
{
	public class RoomPriceMultiplier
	{
		int Id { get; set; }

		public decimal Multiplier { get; set; } = 1.00M;
	}
}
