using System;

namespace Stocks.Billing.Domain.Entities
{
  public class Stock
  {
    public Guid Id { get; set; }

    public string Ticker { get; set; }

    public string Title { get; set; }

    public StockType Type { get; set; }
  }
}
