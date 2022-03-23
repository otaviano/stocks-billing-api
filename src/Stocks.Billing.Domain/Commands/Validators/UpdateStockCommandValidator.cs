using FluentValidation;

namespace Stocks.Billing.Domain.Commands.Validators
{
  public class UpdateStockCommandValidator : AbstractValidator<UpdateStockCommand>
  {
    public UpdateStockCommandValidator()
    {
      RuleFor(x => x.Type)
        .NotEmpty()
        .NotNull();

      RuleFor(x => x.Ticker)
        .NotEmpty()
        .NotNull();

      RuleFor(x => x.Title)
        .NotEmpty()
        .NotNull();
    }
  }
}
