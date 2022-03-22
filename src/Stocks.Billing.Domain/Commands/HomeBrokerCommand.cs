using System;
using Stocks.Billing.Domain.Core.Commands;

namespace Stocks.Billing.Domain.Commands
{
  public abstract class HomeBrokerCommand : Command
  {
    public Guid Hash { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
  }
}
