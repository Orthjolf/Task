using System;
using System.Collections.Generic;
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

			var threads = Enumerable.Range(0, 10).Select(i => new Thread(() =>
			{
				for (var j = 0; j < 10; j++)
				{
					storage.ReserveProduct(users[i], "SomeProduct", 1);
				}
			})
			{
				Name = "thread_" + i
			}).ToList();

			threads.ForEach(t => t.Start());
		}
	}
}