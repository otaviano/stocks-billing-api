using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stocks.Billing.Domain.Interfaces;
using Stocks.Billing.Infra.Data.Context;
using Stocks.Billing.Infra.Data.NoSql.Context;
using Stocks.Billing.Infra.Data.NoSql.Repositories;
using Stocks.Billing.Infra.Data.Repositories;

namespace Stocks.Billing.Infra.IoC.Configurations
{
  public static class DataSetupExtension
  {
    public static void AddSqlConnection(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<StockBillingDbContext>(p =>
      {
        p.UseSqlServer(configuration.GetConnectionString("DbConnection"));
      });
    }

    public static void AddNoSqlConnection(this IServiceCollection services)
    {
      services.AddSingleton(typeof(StockBillingNoSqlDbContext<>));
    }

    public static void AddRepositories(this IServiceCollection services)
    {
      services.AddScoped<IStockRepository, StockRepository>();
      services.AddScoped<IHomeBrokerRepository, HomeBrokerRepository>();
      services.AddScoped<IStockNoSqlRepository, StockNoSqlRepository>();
      services.AddScoped<IHomeBrokerNoSqlRepository, HomeBrokerNoSqlRepository>();
    }
  }
}
