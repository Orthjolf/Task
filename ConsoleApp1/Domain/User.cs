using System.Collections.Generic;
using ConsoleApp1.DataProvider;

namespace ConsoleApp1.Domain
{
	public class User : Entity
	{
		public static Repository<User> Repository => Repository<User>.Instance;

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

		/// <summary>
		/// Информация о бронировании товара
		/// </summary>
		public IEnumerable<BookingInfo> BookingInfos { get; set; }
	}
}