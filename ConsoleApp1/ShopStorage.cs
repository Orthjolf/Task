using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using ConsoleApp1.Domain;

namespace ConsoleApp1
{
	public class ShopStorage
	{
		private Queue<Reservation> Reservations;

		public ShopStorage()
		{
			Reservations = new Queue<Reservation>();
		}

		/// <summary>
		/// Забронировать товар
		/// </summary>
		/// <param name="user">Пользователь</param>
		/// <param name="productName">Наименование товара</param>
		/// <param name="count">Количество бронируемого товара</param>
		public void ReserveProduct(User user, string productName, int count)
		{
			var product = Product.Repository.GetAll().FirstOrDefault(p => p.Name == productName);

			if (product == null)
			{
				Console.WriteLine("Запрашиваемый товар не найден");
				return;
			}

			if (product.Balance < count)
			{
				Console.WriteLine("Не достаточно товара на складе");
				return;
			}

			if (count < 1)
			{
				Console.WriteLine("Должен быть забронирован хотя бы 1 товар");
				return;
			}

			var bookingInfo = new BookingInfo()
			{
				Count = count,
				Date = DateTime.Now,
				ProductId = product.Id,
				UserId = user.Id
			};

			BookingInfo.Repository.Add(bookingInfo);

			product.Balance -= count;
			Product.Repository.Update(product);

			user.ExecutedBookings++;
			User.Repository.Update(user);

			Console.WriteLine("Пользователь {0} забронировал {1} товаров. Остаток на складе - {2}", user.Name, count,
				Product.Repository.GetAll().FirstOrDefault(p => p.Name == productName)?.Balance);
		}

		public class Reservation
		{
			public User User { get; set; }
			public int Count { get; set; }
			public long ProductId { get; set; }
		}
	}
}