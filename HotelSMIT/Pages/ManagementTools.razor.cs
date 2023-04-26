using HotelSMIT.Controllers;
using HotelSMIT.Data;
using HotelSMIT.Data.Models;

namespace HotelSMIT.Pages
{
	public partial class ManagementTools
	{
		public HotelRoom Room { get; set; }

		ManagementService _ManagementService = new();

		private async void AddRoom(int roomNumber, int bedCount, decimal Price)
		{
			HotelRoom newRoom = new HotelRoom();
			newRoom.RoomNumber = roomNumber;
			newRoom.BedCount = bedCount;
			newRoom.Price = Price;
			newRoom.Enabled = true;

			await _ManagementService.AddNewRoom(newRoom);
		}
	}
}
