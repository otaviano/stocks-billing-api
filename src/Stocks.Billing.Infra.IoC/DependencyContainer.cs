using Microsoft.Extensions.DependencyInjection;
using Stocks.Billing.Application.Interfaces;
using Stocks.Billing.Domain.Service;
using Stocks.Billing.Domain.Interfaces;
using Stocks.Billing.Infra.Data.Repositories;
using Stocks.Billing.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stocks.Billing.Domain.Core.Bus;
using Stocks.Billing.Bus;
using MediatR;
using Stocks.Billing.Domain.CommandHandlers;
using Stocks.Billing.Domain.Commands;
using Stocks.Billing.Infra.Data.NoSql.Repositories;

namespace Stocks.Billing.Infra.IoC
{
  public class DependencyContainer
  {
    public static void RegisterServices(IConfiguration configuration, IServiceCollection services)
    {
      RegisterDomain(services);
      RegisterApplication(services);
      RegisterDomainInMemmoryMediatR(services);
      RegisterInfraData(configuration, services);
    }

    private static void RegisterApplication(IServiceCollection services)
    {
      services.AddScoped<IStockService, StockService>();
      services.AddScoped<IHomeBrokerService, HomeBrokerService>();
    }

    private static void RegisterInfraData(IConfiguration configuration, IServiceCollection services)
    {
      services.AddDbContext<StockBillingDbContext>(p =>
      {
        p.UseSqlServer(configuration.GetConnectionString("DbConnection"));
      });

      services.AddScoped<IStockRepository, StockRepository>();
      services.AddScoped<IHomeBrokerRepository, HomeBrokerRepository>();
      services.AddScoped<IStockNoSqlRepository, StockNoSqlRepository>();
      services.AddScoped<IHomeBrokerNoSqlRepository, HomeBrokerNoSqlRepository>();
    }

    private static void RegisterDomain(IServiceCollection services)
    {
      services.AddScoped<IRequestHandler<CreateStockCommand, Unit>, StockCommandHandler>();
      services.AddScoped<IRequestHandler<CreateHomeBrokerCommand, Unit>, HomeBrokerCommandHandler>();
    }

    private static void RegisterDomainInMemmoryMediatR(IServiceCollection services)
    {
      services.AddScoped<IMediatorHandler, InMemoryBus>();
    }
  }
}
