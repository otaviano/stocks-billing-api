using MongoDB.Driver;
using Stocks.Billing.Domain.Settings;

namespace Stocks.Billing.Infra.Data.NoSql.Context
{
  public class StockBillingNoSqlDbContext<T>
  {
    private readonly IMongoDatabase mongoDatabase;
    public IMongoCollection<T> Collection { get; private set; }

    public StockBillingNoSqlDbContext(MongoDbSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      mongoDatabase = client.GetDatabase(settings.Database);

      Collection = mongoDatabase.GetCollection<T>(typeof(T).Name);
    }
  }
}
