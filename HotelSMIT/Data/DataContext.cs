using HotelSMIT.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSMIT.Data
{
	public class DataContext : DbContext
	{
		private static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-HotellProovitöö;Trusted_Connection=True;MultipleActiveResultSets=true";

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(connectionString, builder =>
			{
				builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
			});
			base.OnConfiguring(optionsBuilder);
		}

		public DbSet<User> Users { get; set; }

		public DbSet<HotelRoom> HotelRoom { get; set; } = default!;

		public DbSet<BookedRoom> BookedRoom { get; set; } = default!;
	}
}
