using FluentValidation;

namespace Stocks.Billing.Domain.Commands.Validators
{
  public class CreateStockCommandValidator : AbstractValidator<CreateStockCommand>
  {
    public CreateStockCommandValidator()
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
