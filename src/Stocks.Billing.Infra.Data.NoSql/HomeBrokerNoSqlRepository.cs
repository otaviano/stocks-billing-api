using MongoDB.Driver;
using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Stocks.Billing.Infra.Data.NoSql.Context;

namespace Stocks.Billing.Infra.Data.NoSql.Repositories
{
  public class HomeBrokerNoSqlRepository : IHomeBrokerNoSqlRepository
  {
    private readonly StockBillingNoSqlDbContext<HomeBroker> dbContext;

    public HomeBrokerNoSqlRepository(StockBillingNoSqlDbContext<HomeBroker> dbContext) 
    {
      this.dbContext = dbContext;
    }

    public IEnumerable<HomeBroker> GetAll() =>
      dbContext.Collection.AsQueryable();

    public HomeBroker Get(Guid hash) =>
      dbContext.Collection.AsQueryable().Where(p => p.Id == hash).FirstOrDefault();

    public IEnumerable<HomeBroker> Search(string name) =>
      dbContext.Collection.AsQueryable()
        .Where(p => (string.IsNullOrEmpty(name) || p.Name.Contains(name)));

    public async Task Create(HomeBroker homeBroker) =>
      await dbContext.Collection.InsertOneAsync(homeBroker);
  }
}
