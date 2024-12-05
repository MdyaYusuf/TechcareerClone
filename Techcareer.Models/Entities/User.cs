using Microsoft.AspNetCore.Identity;

namespace Techcareer.Models.Entities;

public class User : IdentityUser
{
  public User()
  {
    
  }

  public string FirstName { get; set; } = default!;
  public string LastName { get; set; } = default!;
  public DateTime BirthDate { get; set; }
  public string City { get; set; } = default!;
  public List<Event> Events { get; set; }
  public List<Course> Courses { get; set; }
}
