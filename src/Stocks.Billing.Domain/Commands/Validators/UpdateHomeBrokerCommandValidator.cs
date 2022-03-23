using FluentValidation;

namespace Stocks.Billing.Domain.Commands.Validators
{
  public class UpdateHomeBrokerCommandValidator : AbstractValidator<UpdateHomeBrokerCommand>
  {
    public UpdateHomeBrokerCommandValidator()
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
