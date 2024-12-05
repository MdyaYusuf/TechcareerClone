using Core.Entities;

namespace Core.Repositories;

public interface IRepository<TEntity, TId> where TEntity : Entity<TId>, new()
{
  Task<List<TEntity>> GetAllAsync();
  ValueTask<TEntity?> GetByIdAsync(TId id);
  ValueTask<TEntity> AddAsync(TEntity entity);
  void Delete(TEntity entity);
  void Update(TEntity entity);
}
