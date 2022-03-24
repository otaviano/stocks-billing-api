using Microsoft.Extensions.DependencyInjection;
using Stocks.Billing.Bus;
using Stocks.Billing.Domain.Core.Bus;

namespace Stocks.Billing.Infra.IoC.Configurations
{
  public static class MessageBrokerSetupExtension
  {
    public static void AddMessageBrokerInMemmory(this IServiceCollection services)
    {
      services.AddScoped<IMediatorHandler, InMemoryBus>();
    }
  }
}
