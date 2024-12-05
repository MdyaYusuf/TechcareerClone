using Core.Entities;
using Techcareer.Models.Enums;

namespace Techcareer.Models.Entities;

public class Course : Entity<int>
{
  public Course()
  {
    
  }

  public string Title { get; set; }
  public string Instructor {  get; set; }
  public string Description { get; set; }
  public Category Category { get; set; }
  public string Image { get; set; }
  public string Level { get; set; }
  public string Duration { get; set; }
  public bool HasCertificate { get; set; }
  public List<User> Users { get; set; }
}
