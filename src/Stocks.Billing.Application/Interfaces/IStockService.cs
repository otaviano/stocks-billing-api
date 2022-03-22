using Stocks.Billing.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stocks.Billing.Application.Interfaces
{
  public interface IStockService
  {
    StockViewModel Get(Guid id);
    IEnumerable<StockViewModel> GetStocks();
    IEnumerable<StockViewModel> Search(string ticker);
    Task Create(StockViewModel model);
  }
}
