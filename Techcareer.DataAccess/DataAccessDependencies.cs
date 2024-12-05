using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Techcareer.DataAccess.Abstracts;
using Techcareer.DataAccess.Concretes;
using Techcareer.DataAccess.Contexts;

namespace Techcareer.DataAccess;

public static class DataAccessDependencies
{
  public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddScoped<IEventRepository, EfEventRepository>();
    services.AddScoped<ICourseRepository, EfCourseRepository>();
    services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
    return services;
  }
}
