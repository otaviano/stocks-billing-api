using Stocks.Billing.Domain.Entities;

namespace Stocks.Billing.Application.ViewModel
{
  public class CreateStockViewModel
  {
    public string Ticker { get; set; }

    public string Title { get; set; }

    public StockType Type { get; set; }
  }
}
