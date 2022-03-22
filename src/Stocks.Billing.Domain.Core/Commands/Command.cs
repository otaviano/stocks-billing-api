using Stocks.Billing.Domain.Core.Events;
using System;

namespace Stocks.Billing.Domain.Core.Commands
{
  public abstract class Command : Message
  {
    public DateTime Timestamp { get; protected set; }

    protected Command()
    {
      Timestamp = DateTime.UtcNow;
    }
  }
}
