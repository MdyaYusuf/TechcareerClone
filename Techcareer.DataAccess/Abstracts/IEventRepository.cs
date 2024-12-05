using Core.Repositories;
using Techcareer.Models.Entities;

namespace Techcareer.DataAccess.Abstracts;

public interface IEventRepository : IRepository<Event, int>
{
  Task<Event?> GetByTitleAsync(string title);
}
