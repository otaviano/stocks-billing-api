using System;
using Stocks.Billing.Domain.Core.Commands;
using Stocks.Billing.Domain.Entities;

namespace Stocks.Billing.Domain.Commands
{
  public abstract class StockCommand : Command
  {
    public Guid Hash { get; set; }

    public string Ticker { get; set; }

    public string Title { get; set; }

    public StockType Type { get; set; }
  }
}
