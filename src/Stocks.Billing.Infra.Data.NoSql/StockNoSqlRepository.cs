using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Interfaces;
using Stocks.Billing.Domain.Queries;
using Stocks.Billing.Infra.Data.NoSql.Context;

namespace Stocks.Billing.Infra.Data.NoSql.Repositories
{
  public class StockNoSqlRepository : IStockNoSqlRepository
  {
    private readonly StockBillingNoSqlDbContext<Stock> dbContext;

    public StockNoSqlRepository(StockBillingNoSqlDbContext<Stock> dbContext) 
    {
      this.dbContext = dbContext;
    }

    public IEnumerable<Stock> GetAll() =>
      dbContext.Collection.AsQueryable();

    public Stock Get(Guid hash) =>
      dbContext.Collection.AsQueryable()
        .FirstOrDefault(p => p.Id == hash);
    public Stock GetBy(string ticker) =>
      dbContext.Collection.AsQueryable()
        .FirstOrDefault(p => string.IsNullOrEmpty(p.Ticker) || p.Ticker == ticker);
    public PagedResult<Stock> Search(StockType type, int pageNumber, int pageSize)
    {
      var source = dbContext.Collection.AsQueryable()
        .Where(p => p.Type == type);

      var result = new PagedResult<Stock>
      {
        Items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize),
        Paging = new PagedResultDetails(pageNumber, pageSize, source.Count())
      };

      return result;
    }
    public async Task Create(Stock stock) =>
      await dbContext.Collection.InsertOneAsync(stock);
  }
}
