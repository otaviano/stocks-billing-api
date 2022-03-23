using System;
using Stocks.Billing.Domain.Entities;

namespace Stocks.Billing.Application.ViewModel
{
  public class StockViewModel
  {
    public Guid Id { get; set; }

    public string Ticker { get; set; }

    public string Title { get; set; }

    public StockType Type { get; set; }
  }
}
