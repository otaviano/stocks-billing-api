using System;
using FluentValidation.Results;
using Stocks.Billing.Domain.Commands.Validators;

namespace Stocks.Billing.Domain.Commands
{
  public class CreateHomeBrokerCommand : HomeBrokerCommand
  {
    public CreateHomeBrokerCommand(Guid hash, string name, string url)
    {
      Hash = hash;
      Name = name;
      Url = url;
    }

    public override ValidationResult Validate()
    {
      return new CreateHomeBrokerCommandValidator().Validate(this);
    }
  }
}
