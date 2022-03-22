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
  public class HomeBrokerNoSqlRepository : NoSqlRepository<HomeBroker>, IHomeBrokerNoSqlRepository
  {
    public HomeBrokerNoSqlRepository(IConfiguration configuration) 
      : base(configuration) { }

    public IEnumerable<HomeBroker> GetAll() =>
      GetCollection().AsQueryable();

    public HomeBroker Get(Guid hash) =>
      GetCollection().AsQueryable().Where(p => p.Id == hash).FirstOrDefault();

    public IEnumerable<HomeBroker> Search(string name) =>
      GetCollection().AsQueryable()
        .Where(p => (string.IsNullOrEmpty(name) || p.Name.Contains(name)));

    public async Task Create(HomeBroker homeBroker) =>
      await GetCollection().InsertOneAsync(homeBroker);
  }
}
