using System;
using FluentValidation.Results;
using Stocks.Billing.Domain.Core.Events;

namespace Stocks.Billing.Domain.Core.Commands
{
  public abstract class Command : Message
  {
    public DateTime Timestamp { get; protected set; }
    public virtual ValidationResult ValidationResult { get; set; }

    protected Command()
    {
      Timestamp = DateTime.UtcNow;
    }
    public abstract ValidationResult Validate();

    public virtual bool IsValid()
    {
      var result = Validate();
      ValidationResult = new ValidationResult(result.Errors);
      return result.IsValid;
    }

  }
}
