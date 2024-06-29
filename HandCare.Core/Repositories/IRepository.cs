using System.Linq.Expressions;

namespace HandCare.Core.Repositories;

public interface IRepository<TEntity, in TKey> where TEntity : class
{
    
    TEntity? Get(TKey id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
    void Add(TEntity entity);
    void Remove(TEntity entity);
    
}