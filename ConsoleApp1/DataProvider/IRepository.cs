using System.Collections.Generic;

namespace ConsoleApp1.DataProvider
{
	public interface IRepository<T>
	{
		/// <summary>
		/// Получить сущность по идентификатору
		/// </summary>
		/// <param name="id">Идентификтаор сущности</param>
		/// <returns>сущность</returns>
		T GetById(long id);

		/// <summary>
		/// Получить все сущности
		/// </summary>
		/// <returns>Сущности</returns>
		IEnumerable<T> GetAll();

		/// <summary>
		/// Добавить сущность в базу данных
		/// </summary>
		/// <param name="entity">Добавляемся сущность</param>
		void Add(T entity);

		/// <summary>
		/// Обновить сущность в базе данных
		/// </summary>
		/// <param name="entity">Обновляемая сущность</param>
		void Update(T entity);

		/// <summary>
		/// Удалить содержимое таблицы в базе
		/// </summary>
		void RemoveAll();
	}
}