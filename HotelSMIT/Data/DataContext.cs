using HotelSMIT.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSMIT.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-HotellProovitöö-20afef3f-7d26-468b-9bb4-0d81e87eb112;Trusted_Connection=True;MultipleActiveResultSets=true");
		}

		public DbSet<User> Users { get; set; }

		public DbSet<HotelSMIT.Data.Models.HotelRoom> HotelRoom { get; set; } = default!;

		public DbSet<HotelSMIT.Data.Models.BookedRoom> BookedRoom { get; set; } = default!;
	}
}
