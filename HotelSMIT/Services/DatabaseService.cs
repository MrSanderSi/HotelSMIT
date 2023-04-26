using HotelSMIT.Controllers;
using HotelSMIT.Data;
using HotelSMIT.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HotelSMIT.Services
{
	public class DatabaseService
	{
		private static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-HotellProovitöö-20afef3f-7d26-468b-9bb4-0d81e87eb112;Trusted_Connection=True;MultipleActiveResultSets=true";

		public void AddRoom(HotelRoom room)
		{
			var options = OptionsBuilder();

			try
			{
				using (var context = new DataContext(options))
				{
					context.HotelRoom.AddAsync(room);

					context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Something went wrong!", ex);
			}
			
		}


		private DbContextOptions<DataContext> OptionsBuilder()
		{
			var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
			optionsBuilder.UseSqlServer(connectionString);

			return optionsBuilder.Options;
		}
	}
}