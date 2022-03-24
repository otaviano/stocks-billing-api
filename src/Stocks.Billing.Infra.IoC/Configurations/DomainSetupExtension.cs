using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Stocks.Billing.Domain.CommandHandlers;
using Stocks.Billing.Domain.Commands;

namespace Stocks.Billing.Infra.IoC.Configurations
{
  public static class DomainSetupExtension
  {
    public static void AddDomain(this IServiceCollection services)
    {
      services.AddScoped<IRequestHandler<CreateStockCommand, Unit>, StockCommandHandler>();
      services.AddScoped<IRequestHandler<CreateHomeBrokerCommand, Unit>, HomeBrokerCommandHandler>();
    }
  }
}
