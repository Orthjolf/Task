using ConsoleApp1.DataProvider;

namespace ConsoleApp1.Domain
{
	public class Product : Entity
	{
		public static Repository<Product> Repository => Repository<Product>.Instance;

		/// <summary>
		/// Название
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Стоимость
		/// </summary>
		public int Price { get; set; }

		/// <summary>
		/// Остаток на складе
		/// </summary>
		public int Balance { get; set; }
	}
}