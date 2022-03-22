using Stocks.Billing.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stocks.Billing.Application.Interfaces
{
    public interface IStockService
    {
        IEnumerable<StockViewModel> SearchStocks(Guid hash, string name);

        IEnumerable<StockViewModel> GetStocks();

        Task Create(StockViewModel model);
    }
}
