using Core.Entities;
using Techcareer.Models.Enums;

namespace Techcareer.Models.Entities;

public class Event : Entity<int>
{
  public Event()
  {
    
  }

  public string Title { get; set; }
  public string Description { get; set; }
  public Tag Tag { get; set; }
  public string Image { get; set; }
  public DateTime Deadline { get; set; }
  public List<User> Users { get; set; }
}
