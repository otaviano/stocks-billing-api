using System;
using Microsoft.Extensions.DependencyInjection;

namespace Stocks.Billing.Infra.IoC.Configurations
{
  public static class HttpSetupExtension
  {
    public static void AddHttpConfiguration(this IServiceCollection services, params Type[] typeFilters)
    {
      services.AddControllers(options =>
      {
        foreach (var item in typeFilters)
        {
          options.Filters.Add(item);
        }
      });
    }
  }
}
