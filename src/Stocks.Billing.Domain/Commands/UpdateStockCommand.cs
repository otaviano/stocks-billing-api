using System;
using FluentValidation.Results;
using Stocks.Billing.Domain.Commands.Validators;

namespace Stocks.Billing.Domain.Commands
{
  public class UpdateStockCommand : StockCommand
  {
    public UpdateStockCommand(Guid id, string ticker, string title, short type)
    {
      Hash = id;
      Ticker = ticker;
      Title = title;
      Type = (Entities.StockType) type;
    }

    public override ValidationResult Validate()
    {
      return new UpdateStockCommandValidator().Validate(this);
    }
  }
}
