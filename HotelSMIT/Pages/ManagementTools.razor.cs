using HotelSMIT.Controllers;
using HotelSMIT.Data;
using HotelSMIT.Data.Models;
using HotelSMIT.UI.Models;

namespace HotelSMIT.Pages
{
	public partial class ManagementTools
	{
		public HotelRoom Room { get; set; } = new();

		RoomModel RoomModel { get; set; } = new();

		ManagementService _ManagementService = new();

		private async void AddRoom()
		{
			HotelRoom newRoom = new()
			{
				RoomNumber = RoomModel.RoomNumber,
				BedCount = RoomModel.BedCount,
				Price = RoomModel.Price,
				Enabled = true
			};

			await _ManagementService.AddNewRoom(newRoom);
		}
	}
}
