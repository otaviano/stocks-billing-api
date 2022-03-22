using FluentValidation;

namespace Stocks.Billing.Domain.Commands.Validators
{
  public class CreateHomeBrokerCommandValidator : AbstractValidator<CreateHomeBrokerCommand>
  {
    public CreateHomeBrokerCommandValidator()
    {
      RuleFor(x => x.Name)
        .NotEmpty()
        .NotNull();

      RuleFor(x => x.Url)
      .NotEmpty()
      .NotNull();
    }
  }
}
