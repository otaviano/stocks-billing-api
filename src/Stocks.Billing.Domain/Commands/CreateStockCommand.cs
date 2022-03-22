using FluentValidation.Results;
using Stocks.Billing.Domain.Commands.Validators;

namespace Stocks.Billing.Domain.Commands
{
  public class CreateStockCommand : StockCommand
  {
    public CreateStockCommand(string ticker, string title, short type)
    {
      Ticker = ticker;
      Title = title;
      Type = (Entities.StockType) type;
    }

    public override ValidationResult Validate()
    {
      return new CreateStockCommandValidator().Validate(this);
    }
  }
}
