using ConsoleApp1.DataProvider;

namespace ConsoleApp1.Domain
{
	/// <summary>
	/// Продукт на складе
	/// </summary>
	public class Product : Entity
	{
		public static IRepository<Product> Repository => Repository<Product>.Instance;

		/// <summary>
		/// Название
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Стоимость
		/// </summary>
		public int Price { get; set; }

		/// <summary>
		/// Остаток
		/// </summary>
		public int Balance { get; set; }
	}
}