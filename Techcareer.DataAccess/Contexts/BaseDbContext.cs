using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Techcareer.Models.Entities;

namespace Techcareer.DataAccess.Contexts;

public class BaseDbContext : IdentityDbContext<User, IdentityRole, string>
{
  public BaseDbContext(DbContextOptions opt) : base(opt)
  {
    
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public DbSet<Event> Events { get; set; }
  public DbSet<Course> Courses { get; set; }
}
