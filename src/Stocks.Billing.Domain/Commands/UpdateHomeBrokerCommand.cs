using System;
using FluentValidation.Results;
using Stocks.Billing.Domain.Commands.Validators;

namespace Stocks.Billing.Domain.Commands
{
  public class UpdateHomeBrokerCommand : HomeBrokerCommand
  {
    public UpdateHomeBrokerCommand(Guid hash, string name, string url)
    {
      Hash = hash;
      Name = name;
      Url = url;
    }

    public override ValidationResult Validate()
    {
      return new UpdateHomeBrokerCommandValidator().Validate(this);
    }
  }
}
