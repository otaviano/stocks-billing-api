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

    public PagedResult<HomeBroker> Search(string name, int pageNumber, int pageSize)
    {
      var source = dbContext.Collection.AsQueryable()
        .Where(p => (string.IsNullOrEmpty(name) || p.Name.Contains(name)));

      var result = new PagedResult<HomeBroker>
      {
        Items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize),
        Paging = new PagedResultDetails(pageNumber, pageSize, source.Count())
      };

      return result;
    }
    public async Task Create(HomeBroker homeBroker) =>
      await dbContext.Collection.InsertOneAsync(homeBroker);
  }
}
