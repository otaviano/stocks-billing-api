using System;
using System.Collections.Generic;
using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Queries;

namespace Stocks.Billing.Domain.Interfaces
{
  public interface IStockNoSqlRepository : IStockRepository
  {
    Stock Get(Guid hash);
    IEnumerable<Stock> GetAll();
    PagedResult<Stock> Search(StockType type, int pageNumber, int pageSize);
    Stock GetBy(string ticker);
  }
}
