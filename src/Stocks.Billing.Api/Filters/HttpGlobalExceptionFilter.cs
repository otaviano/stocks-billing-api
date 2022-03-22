using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Stocks.Billing.Api.Extensions;
using Stocks.Billing.Domain.Core.Exceptions;
using System;
using System.Security.Authentication;

namespace Stocks.Billing.Api.Filters
{
  public partial class HttpGlobalExceptionFilter : IExceptionFilter
  {
    private readonly IWebHostEnvironment env;
    private readonly ILogger<HttpGlobalExceptionFilter> logger;

    public HttpGlobalExceptionFilter(
      IWebHostEnvironment env, 
      ILogger<HttpGlobalExceptionFilter> logger)
    {
      this.env = env;
      this.logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
      var exception = context.Exception;
      var statusCode = StatusCodes.Status500InternalServerError;
      var message = "Oops! We are sorry but your request could not be processed. The development team has already been notified.";

      if (exception.GetType() == typeof(AggregateException) && exception.InnerException != null)
      {
        exception = exception.InnerException;
      }
      logger?.LogError(exception, exception.Message);


      switch (exception)
      {
        case BaseInvalidClientOperationException baseInvalidClientOperationException:
          message = baseInvalidClientOperationException.Message;
          statusCode = (int) baseInvalidClientOperationException.StatusCode;
          break;
        case AuthenticationException authenticationException:
          message = authenticationException.Message;
          statusCode = StatusCodes.Status401Unauthorized;
          break;
        case NotFoundException notFoundException:
          message = notFoundException.Message;
          statusCode = StatusCodes.Status404NotFound;
          break;
        case NotImplementedException _:
          statusCode = StatusCodes.Status501NotImplemented;
          break;
      }

      var json = GetJsonErrorResponse(exception, message);

      if (env.IsDevelopment())
      {
        json.Errors[0].Message = context.Exception.ToString();
      }

      context.Result = new ObjectResult(json) { StatusCode = statusCode };
      context.HttpContext.Response.StatusCode = statusCode;
      context.ExceptionHandled = true;
    }

    public JsonErrorResponse GetJsonErrorResponse(Exception exception, string message)
    {
      if (exception is BaseInvalidClientOperationException baseInvalidClientOperationException)
      {
        return baseInvalidClientOperationException.Result.ToJsonErrorResponse();
      }

      return new JsonErrorResponse(new JsonError(message));
    }
  }
}
