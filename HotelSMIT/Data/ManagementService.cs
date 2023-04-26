using HotelSMIT.Data.Models;
using HotelSMIT.Services;

namespace HotelSMIT.Data
{
	public class ManagementService
	{
		DatabaseService dbService = new DatabaseService();

		public Task AddNewRoom(HotelRoom room)
		{
			dbService.AddRoom(room);

			return Task.CompletedTask;
		}
	}
}
