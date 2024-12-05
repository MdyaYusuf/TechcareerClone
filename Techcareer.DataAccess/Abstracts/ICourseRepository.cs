using Core.Repositories;
using Techcareer.Models.Entities;

namespace Techcareer.DataAccess.Abstracts;

public interface ICourseRepository : IRepository<Course, int>
{
  Task<Course?> GetByTitleAsync(string title);
}
