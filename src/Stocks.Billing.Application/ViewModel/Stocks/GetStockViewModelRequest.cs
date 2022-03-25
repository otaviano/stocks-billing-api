namespace Stocks.Billing.Application.ViewModel
{
  public class GetStockViewModelRequest
  {
    public string Ticker { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }

  }
}
