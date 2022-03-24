using Microsoft.Extensions.DependencyInjection;

namespace Stocks.Billing.Infra.IoC.Configurations
{
  public static class ApiVersioningExtension
  {
    public static IServiceCollection AddApiVersioning(this IServiceCollection services)
    {
      services.AddVersionedApiExplorer(options =>
      {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
      });

      return services;
    }
  }
}
