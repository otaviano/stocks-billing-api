using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Stocks.Billing.Domain.Entities;

namespace Stocks.Billing.Infra.Data.NoSql.Repositories
{
  public abstract class NoSqlRepository<T> where T : Entity
  {
    private readonly IMongoDatabase mongoDatabase;

    public NoSqlRepository(IConfiguration configuration)
    {
      var client = new MongoClient(configuration.GetConnectionString("MongoConnection"));
      mongoDatabase = client.GetDatabase("stocks-billing");
    }
    protected IMongoCollection<T> GetCollection() =>
      mongoDatabase.GetCollection<T>(typeof(T).Name);
  }
}
