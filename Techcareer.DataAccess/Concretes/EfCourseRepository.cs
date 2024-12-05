using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Techcareer.DataAccess.Abstracts;
using Techcareer.DataAccess.Contexts;
using Techcareer.Models.Entities;

namespace Techcareer.DataAccess.Concretes;

public class EfCourseRepository : EfBaseRepository<BaseDbContext, Course, int>, ICourseRepository
{
  public EfCourseRepository(BaseDbContext context) : base(context)
  {
    
  }

  public async Task<Course?> GetByTitleAsync(string title)
  {
    return await _context.Courses.FirstOrDefaultAsync(c => c.Title == title);
  }
}
