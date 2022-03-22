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
  public class HomeBrokerNoSqlRepository : IHomeBrokerNoSqlRepository
  {
    private readonly IMongoDatabase mongoDatabase;

    public HomeBrokerNoSqlRepository(IConfiguration configuration)
    {
      var client = new MongoClient(configuration.GetConnectionString("MongoConnection"));
      mongoDatabase = client.GetDatabase("read-data");
    }

    private IMongoCollection<T> GetCollection<T>() => 
      mongoDatabase.GetCollection<T>(nameof(T));

    public IEnumerable<HomeBroker> GetAll() =>
      GetCollection<HomeBroker>().AsQueryable();

    public IEnumerable<HomeBroker> Search(Guid hash, string name) =>
      GetCollection<HomeBroker>().AsQueryable()
        .Where(p => p.Id == hash || p.Name == name);
    
    public async Task Create(HomeBroker homeBroker) =>
      await GetCollection<HomeBroker>().InsertOneAsync(homeBroker);
  }
}
