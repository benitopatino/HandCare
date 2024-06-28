using System.Linq.Expressions;
using HandCare.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HandCare.Data.Repositories;

public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
{
    protected readonly DbContext Context;
    private readonly DbSet<TEntity> _set;

    public Repository(DbContext context)
    {
        Context = context;
        _set = Context.Set<TEntity>();
    }
    
    public TEntity? Get(TKey id)
    {
        return _set.Find(id) ?? null;
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _set.ToList();
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _set.Where(predicate);
    }

    public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return _set.SingleOrDefault(predicate) ?? null;
    }

    public void Add(TEntity entity)
    {
        _set.Add(entity);
    }

    public void Remove(TEntity entity)
    {
        _set.Remove(entity);
    }
}