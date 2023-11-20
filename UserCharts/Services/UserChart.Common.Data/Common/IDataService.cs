using System.Linq.Expressions;

namespace UserChart.Data.Common;

public interface IDataService<TEntity>
    where TEntity: class
{
    Task Add(TEntity entity);

    Task AddMany(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    void Delete(TEntity entity);
    
    IQueryable<TEntity> GetQuery(
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity, object>>? orderBy = null,
        bool descending = false,
        int? skip = null,
        int? take = null);

}