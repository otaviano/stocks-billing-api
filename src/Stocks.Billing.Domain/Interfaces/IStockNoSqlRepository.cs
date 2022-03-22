using System;
using System.Collections.Generic;
using Stocks.Billing.Domain.Entities;

namespace Stocks.Billing.Domain.Interfaces
{
  public interface IStockNoSqlRepository : IStockRepository
  {
    IEnumerable<Stock> GetAll();
    IEnumerable<Stock> Search(Guid hash, string ticker);
  }
}
