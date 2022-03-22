using System;

namespace Stocks.Billing.Domain.Entities
{
  public class Stock : Entity
  {
    public string Ticker { get; set; }

    public string Title { get; set; }

    public StockType Type { get; set; }
  }
}
