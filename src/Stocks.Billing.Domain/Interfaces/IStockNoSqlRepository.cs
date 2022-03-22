using System;
using System.Collections.Generic;
using Stocks.Billing.Domain.Entities;

namespace Stocks.Billing.Domain.Interfaces
{
  public interface IStockNoSqlRepository : IStockRepository
  {
    Stock Get(Guid hash);
    IEnumerable<Stock> GetAll();
    IEnumerable<Stock> Search(string ticker);
  }
}
