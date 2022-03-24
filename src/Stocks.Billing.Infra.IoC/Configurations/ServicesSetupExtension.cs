using Microsoft.Extensions.DependencyInjection;
using Stocks.Billing.Application.Interfaces;
using Stocks.Billing.Domain.Service;

namespace Stocks.Billing.Infra.IoC.Configurations
{
  public static class ServicesSetupExtension
  {
    public static void AddServices(this IServiceCollection services)
    {
      services.AddScoped<IStockService, StockService>();
      services.AddScoped<IHomeBrokerService, HomeBrokerService>();
    }
  }
}
