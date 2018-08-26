using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using ConsoleApp1.Domain;

namespace ConsoleApp1.DataProvider
{
	public class ApplicationDbContext : DbContext
	{
		public static ApplicationDbContext Instance => _instance ?? (_instance = new ApplicationDbContext());

		private static ApplicationDbContext _instance;

		private const string ConnectionString = "DbConnection";

		private ApplicationDbContext()
			: base(ConnectionString)
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<BookingInfo> BookingInfos { get; set; }
	}
}