using Core.Exceptions;
using Core.Responses;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace Techcareer.WebApi.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
  public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
  {
    ReturnModel<List<string>> Errors = new ReturnModel<List<string>>();
    httpContext.Response.ContentType = "application/json";
    Errors.Success = false;
    Errors.Message = exception.Message;

    if (exception.GetType() == typeof(NotFoundException))
    {
      httpContext.Response.StatusCode = 404;
      Errors.StatusCode = 404;
    }

    else if (exception.GetType() == typeof(BusinessException))
    {
      httpContext.Response.StatusCode = 400;
      Errors.StatusCode = 400;
    }

    else
    {
      httpContext.Response.StatusCode = 500;
      Errors.StatusCode = 500;
    }

    await httpContext.Response.WriteAsync(JsonSerializer.Serialize(Errors));

    return true;
  }
}
