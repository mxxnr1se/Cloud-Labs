using System.Linq.Expressions;
using DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace DAL.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetByIdAsync(int id);
    Task<TEntity> GetByIdAsyncAsTracking(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> expression);
    Task<IEnumerable<TEntity>> GetManyAsTrackingAsync(Expression<Func<TEntity, bool>> expression);
    Task CreateAsync(TEntity entity);
    void Remove(TEntity entity);
    void Update(TEntity entity);
}