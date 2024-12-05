using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Techcareer.DataAccess.Abstracts;
using Techcareer.DataAccess.Contexts;
using Techcareer.Models.Entities;

namespace Techcareer.DataAccess.Concretes;

public class EfEventRepository : EfBaseRepository<BaseDbContext, Event, int>, IEventRepository
{
  public EfEventRepository(BaseDbContext context) : base(context)
  {
    
  }

  public async Task<Event?> GetByTitleAsync(string title)
  {
    return await _context.Events.FirstOrDefaultAsync(e => e.Title == title);
  }
}
