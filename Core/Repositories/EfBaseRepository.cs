using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories;

public class EfBaseRepository<TContext, TEntity, TId> : IRepository<TEntity, TId>
  where TEntity : Entity<TId>, new()
  where TContext : DbContext
{
  protected TContext _context { get; }
  public EfBaseRepository(TContext context)
  {
    _context = context;
  }

  public async ValueTask<TEntity> AddAsync(TEntity entity)
  {
    entity.CreatedDate = DateTime.Now;
    await _context.Set<TEntity>().AddAsync(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public async Task<List<TEntity>> GetAllAsync()
  {
    return await _context.Set<TEntity>().ToListAsync();
  }

  public async ValueTask<TEntity?> GetByIdAsync(TId id)
  {
    return await _context.Set<TEntity>().FindAsync(id);
  }

  public void Delete(TEntity entity)
  {
    _context.Set<TEntity>().Remove(entity);
    _context.SaveChangesAsync();
  }

  public void Update(TEntity entity)
  {
    _context.Set<TEntity>().Update(entity);
    _context.SaveChangesAsync();
  }
}
