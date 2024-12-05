using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Techcareer.Service.Abstracts;
using Techcareer.Service.Concretes;
using Techcareer.Service.Profiles;
using Techcareer.Service.Rules;

namespace Techcareer.Service;

public static class ServiceDependencies
{
  public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
  {
    services.AddAutoMapper(typeof(MappingProfiles));
    services.AddScoped<EventBusinessRules>();
    services.AddScoped<CourseBusinessRules>();
    services.AddScoped<UserBusinessRules>();
    services.AddScoped<RoleBusinessRules>();
    services.AddScoped<IJwtService, JwtService>();
    services.AddScoped<IAuthenticationService, AuthenticationService>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IEventService, EventService>();
    services.AddScoped<ICourseService, CourseService>();
    services.AddScoped<IRoleService, RoleService>();
    services.AddFluentValidationAutoValidation();
    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    return services;
  }
}
