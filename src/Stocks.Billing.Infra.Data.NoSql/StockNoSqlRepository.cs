using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Interfaces;
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

    public IEnumerable<Stock> Search(string ticker) =>
      dbContext.Collection.AsQueryable()
        .Where(p => string.IsNullOrEmpty(p.Ticker) || p.Ticker == ticker);
    
    public async Task Create(Stock stock) =>
      await dbContext.Collection.InsertOneAsync(stock);
  }
}
