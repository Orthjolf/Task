using System;
using ConsoleApp1.DataProvider;

namespace ConsoleApp1.Domain
{
	/// <summary>
	/// Информация о бронировании товара
	/// </summary>
	public class BookingInfo : Entity
	{
		public static IRepository<BookingInfo> Repository => Repository<BookingInfo>.Instance;

		/// <summary>
		/// Дата бронирования товара
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// Идентификатор товара
		/// </summary>
		public long ProductId { get; set; }

		/// <summary>
		/// Идентификатор пользователя, забронировавшего товар
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// Количество единиц забронированного товара
		/// </summary>
		public int Count { get; set; }
	}
}