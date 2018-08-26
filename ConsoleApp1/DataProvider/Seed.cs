using ConsoleApp1.Domain;

namespace ConsoleApp1.DataProvider
{
	public static class Seed
	{
		/// <summary>
		/// Заполнение бд
		/// </summary>
		private static void Fill(int balance, int users)
		{
			Product.Repository.Add(new Product
			{
				Name = "SomeProduct",
				Price = 50,
				Balance = balance
			});

			for (var i = 0; i < users; i++)
			{
				User.Repository.Add(new User
				{
					Name = "User_" + i,
					Money = 10
				});
			}
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
		/// <param name="users">Количество пользователей</param>
		public static void Reset(int balance, int users)
		{
			Clear();
			Fill(balance, users);
		}
	}
}