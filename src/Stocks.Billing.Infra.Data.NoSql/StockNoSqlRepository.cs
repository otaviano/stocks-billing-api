using MongoDB.Driver;
using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Stocks.Billing.Infra.Data.NoSql.Repositories
{
  public class StockNoSqlRepository : NoSqlRepository<Stock>, IStockNoSqlRepository
  {
    public StockNoSqlRepository(IConfiguration configuration) 
      : base(configuration) { }

    public IEnumerable<Stock> GetAll() =>
      GetCollection().AsQueryable();

    public Stock Get(Guid hash) =>
      GetCollection().AsQueryable()
        .FirstOrDefault(p => p.Id == hash);

    public IEnumerable<Stock> Search(string ticker) =>
      GetCollection().AsQueryable()
        .Where(p => string.IsNullOrEmpty(p.Ticker) || p.Ticker == ticker);
    
    public async Task Create(Stock stock) =>
      await GetCollection().InsertOneAsync(stock);
  }
}
