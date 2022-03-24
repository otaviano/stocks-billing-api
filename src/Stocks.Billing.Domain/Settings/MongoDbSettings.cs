namespace Stocks.Billing.Domain.Settings
{
  public class MongoDbSettings
  {
    public const string SectionName = "MongoDbSettings";

    public string ConnectionString { get; set; }
    public string Database { get; set; }
  }
}
