using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using ConsoleApp1.Domain;

namespace ConsoleApp1.DataProvider
{
	public static class Seed
	{
		/// <summary>
		/// Заполнение бд
		/// </summary>
		private static void Fill(int balance)
		{
			Product.Repository.Add(new Product
			{
				Name = "SomeProduct",
				Price = 50,
				Balance = balance
			});
		}

		/// <summary>
		/// Очистка бд
		/// </summary>
		private static void Clear()
		{
			User.Repository.RemoveAll();
			Product.Repository.RemoveAll();
			BookingInfo.Repository.RemoveAll();
		}

		/// <summary>
		/// Сбрасывает базу к исходному состоянию
		/// </summary>
		/// <param name="balance">Количество товара на складе</param>
		public static void Reset(int balance)
		{
			Clear();
			Fill(balance);
		}

		/// <summary>
		/// Создает пользоватлеей в базе данных
		/// </summary>
		/// <param name="count">Количество пользователей</param>
		public static void CreateUsersInDataBase(int count)
		{
			for (var i = 0; i < count; i++)
			{
				User.Repository.Add(new User
				{
					Name = "User_" + i,
					ExecutedBookings = 0
				});
			}
		}
	}
}