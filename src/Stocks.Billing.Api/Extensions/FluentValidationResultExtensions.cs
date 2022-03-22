using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Stocks.Billing.Api.Filters;

namespace Stocks.Billing.Api.Extensions
{
  public static class FluentValidationResultExtensions
  {
    public static JsonErrorResponse ToJsonErrorResponse(this ValidationResult result)
    {
      var list = new List<JsonError>();
      var response = new JsonErrorResponse();
      
      if (result?.Errors != null && result.Errors.Any())
      {
        list.AddRange(result.Errors.Select(x => 
          new JsonError() { Message = BuildErrorMessage(x) }));
      }

      response.Errors = list.ToArray();
      
      return response;
    }

    private static string BuildErrorMessage(ValidationFailure validationFailure)
    {
      return string.IsNullOrWhiteSpace(validationFailure.PropertyName)
          ? validationFailure.ErrorMessage
          : validationFailure.PropertyName + " " + validationFailure.ErrorMessage;
    }
  }
}
