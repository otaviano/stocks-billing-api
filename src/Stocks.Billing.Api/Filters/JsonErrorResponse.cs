using FluentValidation.Results;
using Stocks.Billing.Domain.Exceptions;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Stocks.Billing.Api.Filters
{
  [ExcludeFromCodeCoverage]
  public class JsonErrorResponse
  {
    public JsonError[] Errors { get; set; }

    public JsonErrorResponse() { }

    public JsonErrorResponse(string errorMessage)
    {
      var errors = new List<JsonError> { new JsonError(errorMessage) };

      Errors = errors.ToArray();
    }

    public JsonErrorResponse(FailedCommandExecutionException ex)
    {
      var errors = new List<JsonError> { new JsonError(ex.Message) };

      Errors = errors.ToArray();
    }

    public JsonErrorResponse(JsonError error)
    {
      var errors = new List<JsonError> { error };

      Errors = errors.ToArray();
    }

    public JsonErrorResponse(IEnumerable<ValidationFailure> failures)
    {
      var errors = new List<JsonError>();

      foreach (var failure in failures)
      {
        errors.Add(new JsonError(failure.ErrorMessage));
      }

      Errors = errors.ToArray();
    }
  }
}
