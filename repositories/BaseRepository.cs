using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Model.context;

namespace Model.repositories;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
	private readonly ApplicationContext _context;
	private readonly DbSet<TEntity> _dbSet;

	public BaseRepository(ApplicationContext context)
	{
		this._context = context;
		this._dbSet = context.Set<TEntity>();
	}

	public virtual IEnumerable<TEntity> GetWithRawSql(string query,
		params object[] parameters)
	{
		return _dbSet.FromSql($"{query} {parameters}").ToList();
	}

	public virtual IEnumerable<TEntity> Get(
		Expression<Func<TEntity, bool>>? filter = null,
		Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
		string? includeProperties = "")
	{
		IQueryable<TEntity> query = _dbSet;

		if (filter != null)
		{
			query = query.Where(filter);
		}

		if (includeProperties != null)
		{
			query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
		}


		return orderBy != null ? orderBy(query).ToList() : query.ToList();
	}

	public virtual TEntity GetById(object id)
	{
		return _dbSet.Find(id)!;
	}

	public virtual void Insert(TEntity entity)
	{
		_dbSet.Add(entity);
	}

	public virtual void Delete(object id)
	{
		TEntity entityToDelete = _dbSet.Find(id)!;
		Delete(entityToDelete);
	}

	public virtual void Delete(TEntity entityToDelete)
	{
		if (_context.Entry(entityToDelete).State == EntityState.Detached)
		{
			_dbSet.Attach(entityToDelete);
		}
		_dbSet.Remove(entityToDelete);
	}

	public virtual void Update(TEntity entityToUpdate)
	{
		_dbSet.Attach(entityToUpdate);
		_context.Entry(entityToUpdate).State = EntityState.Modified;
	}
}