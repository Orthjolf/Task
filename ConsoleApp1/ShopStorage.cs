using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using ConsoleApp1.DataProvider;
using ConsoleApp1.Domain;

namespace ConsoleApp1
{
	public class ShopStorage
	{
		/// <summary>
		/// Забронировать товар
		/// </summary>
		/// <param name="user">Пользователь, который осуществляет бронирование</param>
		/// <param name="productName">Наименование товара</param>
		/// <param name="count">Количество бронируемого товара</param>
		public void ReserveProduct(User user, string productName, int count)
		{
			lock (ApplicationDbContext.Instance)
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

				Console.WriteLine("Поток: {0}. Пользователь {1} забронировал {2} товар. Остаток на складе - {3}.",
					Thread.CurrentThread.Name, user.Name,
					count,
					Product.Repository.GetAll().FirstOrDefault(p => p.Name == productName)?.Balance);
			}
		}
	}
}