using System;
using System.Linq;
using System.Threading;
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
			
			var t1 = new Thread(() =>
			{
				storage.ReserveProduct(users[0], "SomeProduct", 1);
			});
			
			var t2 = new Thread(() =>
			{
				storage.ReserveProduct(users[1], "SomeProduct", 2);
			});
		}
	}
}
