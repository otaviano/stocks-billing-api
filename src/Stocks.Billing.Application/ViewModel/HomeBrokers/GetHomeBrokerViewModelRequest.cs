using System;

namespace Stocks.Billing.Application.ViewModel
{
  public class GetHomeBrokerViewModelRequest
  {
    public string Name { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
  }
}
