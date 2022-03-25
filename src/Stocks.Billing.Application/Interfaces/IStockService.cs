using Stocks.Billing.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stocks.Billing.Application.Interfaces
{
  public interface IStockService
  {
    GetStockViewModelResponse Get(Guid id);
    GetStockViewModelResponse GetBy(string ticker);
    IEnumerable<GetStockViewModelResponse> GetStocks();
    Task<Guid> Create(CreateStockViewModel model);
    Task Update(UpdateStockViewModel model);
  }
}
