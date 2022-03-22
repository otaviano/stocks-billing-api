using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FluentValidation.Results;

namespace Stocks.Billing.Domain.Core.Exceptions
{
  public class InvalidCommandException : BaseInvalidClientOperationException
  {
    private const string InvalidCommand = "Invalid Command";

    public InvalidCommandException(
      ValidationResult result, 
      string msg, 
      Exception innerException = null) 
        : base(
            result, 
            GetEnrichedExceptionMessage(result, msg),
            HttpStatusCode.BadRequest, 
            innerException) { }

    public InvalidCommandException(
      string msg, 
      Exception innerException = null) : base(msg, HttpStatusCode.BadRequest, innerException)
    {
      Result = new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("", msg) });
    }

    public InvalidCommandException(
      ValidationResult result, 
      Exception innerException = null) 
        : this(result, InvalidCommand, innerException) { }

    public static InvalidCommandException GetCommandInvalidException(ValidationResult result)
    {
      var errorMessage = InvalidCommand;
      if (result?.Errors != null)
      {
        errorMessage = string.Join(' ', result.Errors.Select(x => x?.ErrorMessage));
      }
      return new InvalidCommandException(result, errorMessage);
    }

    static string GetEnrichedExceptionMessage(ValidationResult result, string msg)
    {
      if (result?.Errors != null)
        msg += ": " + result.ToString(", ");
      return msg;
    }
  }
}
