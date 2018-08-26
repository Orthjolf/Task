using ConsoleApp1.DataProvider;

namespace ConsoleApp1.Domain
{
	/// <summary>
	/// Пользователь, который осуществляет бронирование
	/// </summary>
	public class User : Entity
	{
		public static IRepository<User> Repository => Repository<User>.Instance;

		/// <summary>
		/// Имя
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Денежная сумма
		/// </summary>
		public int Money { get; set; }

		/// <summary>
		/// Осуществлено бронирований
		/// </summary>
		public int ExecutedBookings { get; set; }
	}
}