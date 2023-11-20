using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UsersChart.Data;

namespace UserChart.Data.Common;

public class DataService<TEntity> : IDataService<TEntity>
    where TEntity : class
{
    private readonly UsersChartDbContext db;

    protected DataService(UsersChartDbContext db)
        => this.db = db;

    private DbSet<TEntity> DbSet
        => db.Set<TEntity>();

    public async Task Add(TEntity entity)
        => await db.AddAsync(entity);

    public async Task AddMany(IEnumerable<TEntity> entities)
        => await db.AddRangeAsync(entities);

    public void Update(TEntity entity)
        => db.Update(entity);

    public void Delete(TEntity entity)
        => db.Remove(entity);
    
    public IQueryable<TEntity> GetQuery(
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity, object>>? orderBy = null,
        bool descending = false,
        int? skip = null,
        int? take = 10)
    {
        var query = DbSet.AsQueryable();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            query = descending
                ? query.OrderByDescending(orderBy)
                : query.OrderBy(orderBy);
        }

        if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }

        if (take.HasValue)
        {
            query = query.Take(take.Value);
        }

        return query;
    }
}