using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ConsoleApp1.DataProvider;
using ConsoleApp1.Domain;

namespace ConsoleApp1
{
	class Program
	{
		private static void Main(string[] args)
		{
			const int productsInStorage = 995;
			Seed.Reset(productsInStorage);
			Seed.CreateUsersInDataBase(10);

			//При наличии 995 товаров на складе, запускается 10 потоков по 100 бронирований.
			//Последние 5 бронирований не удаются из-за недостатка товара.
			var threads = CreateThreads(10);
			threads.ForEach(t => t.Start());
		}

		/// <summary>
		/// Создать коллекцию потоков для выполнения
		/// </summary>
		/// <param name="count">Количество потоков, бронирующих товар</param>
		/// <returns>Коллекция потоков</returns>
		private static List<Thread> CreateThreads(int count)
		{
			var storage = new ShopStorage();
			var users = User.Repository.GetAll().ToList();

			return Enumerable.Range(0, count).Select(i =>
				new Thread(() => Enumerable.Range(0, 100)
					.ToList()
					.ForEach(j => storage.ReserveProduct(users[i], "SomeProduct", 1)))
				{
					Name = "thread_" + i
				}).ToList();
		}
	}
}