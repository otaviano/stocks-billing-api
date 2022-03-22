using Stocks.Billing.Domain.Core.Commands;
using Stocks.Billing.Domain.Core.Exceptions;

namespace Stocks.Billing.Domain.Core.CommandHandlers
{
  public abstract class CommandHandler
  {
    public virtual void ValidateAndThrow(Command command)
    {
      if (command.IsValid()) return;

      throw InvalidCommandException.GetCommandInvalidException(command.ValidationResult);
    }
  }
}
