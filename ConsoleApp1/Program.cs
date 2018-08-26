using System;
using System.Linq;
using ConsoleApp1.DataProvider;
using ConsoleApp1.Domain;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			const int itemsInStorage = 1000;
			const int usersCount = 25;
			Seed.Reset(itemsInStorage, usersCount);

			var storage = new ShopStorage();

			var users = User.Repository.GetAll().ToList();

			for (var i = 0; i < 100; i++)
			{
				var random = new Random();
				var randomUser = users[random.Next(users.Count - 1)];
				storage.ReserveProduct(randomUser, "Bread", random.Next(1, 4));
			}
		}
	}
}