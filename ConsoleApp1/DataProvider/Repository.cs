using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using ConsoleApp1.Domain;

namespace ConsoleApp1.DataProvider
{
	public class Repository<T> : IRepository<T> where T : Entity
	{
		public static Repository<T> Instance => _instance ?? (_instance = new Repository<T>());

		private static Repository<T> _instance;

		private readonly DbSet<T> _dbSet;

		private readonly ApplicationDbContext _db;

		private Repository()
		{
			_db = ApplicationDbContext.Instance;
			_dbSet = _db.Set<T>();
		}

		public T GetById(long id)
		{
			return _dbSet.FirstOrDefault(e => e.Id == id);
		}

		public IEnumerable<T> GetAll()
		{
			return _dbSet.ToList();
		}

		public void Add(T entity)
		{
			_dbSet.Add(entity);
			_db.SaveChanges();
		}

		public void Update(T entity)
		{
			_dbSet.AddOrUpdate(entity);
			_db.SaveChanges();
		}

		public void RemoveAll()
		{
			_dbSet.RemoveRange(_dbSet.ToList());
			_db.SaveChanges();
		}
	}
}