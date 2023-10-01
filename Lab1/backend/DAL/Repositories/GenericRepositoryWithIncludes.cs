using System.Linq.Expressions;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DAL.Repositories;

public abstract class GenericRepositoryWithIncludes<T> : IRepository<T> where T : BaseEntity
{
    protected GenericRepositoryWithIncludes(DbContext context)
    {
        DbSet = context.Set<T>();
    }

    protected DbSet<T> DbSet { get; }

    public async Task<T> GetByIdAsync(int id)
    {
        var entity = await DbSetWithAllProperties().AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        return entity;
    }

    public async Task<T> GetByIdAsyncAsTracking(int id)
    {
        var entity = await DbSetWithAllProperties().FirstOrDefaultAsync(p => p.Id == id);

        return entity;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var entities = await DbSetWithAllProperties().AsNoTracking().ToListAsync();

        return entities;
    }

    public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> expression)
    {
        var entities = await DbSetWithAllProperties().Where(expression).AsNoTracking().ToListAsync();

        return entities;
    }

    public async Task<IEnumerable<T>> GetManyAsTrackingAsync(Expression<Func<T, bool>> expression)
    {
        var entities = await DbSetWithAllProperties().Where(expression).ToListAsync();

        return entities;
    }

    public async Task CreateAsync(T entity)
    {
        await DbSet.AddAsync(entity);
    }

    public void Remove(T entity)
    {
        DbSet.Remove(entity);
    }

    public void Update(T entity)
    {
        DbSet.Update(entity);
    }

    protected abstract IQueryable<T> DbSetWithAllProperties();
}