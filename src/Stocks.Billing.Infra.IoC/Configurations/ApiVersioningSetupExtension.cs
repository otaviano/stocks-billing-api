using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;

namespace Stocks.Billing.Infra.IoC.Configurations
{
  public static class ApiVersioningSetupExtension
  {
    public static IServiceCollection AddApiVersion(this IServiceCollection services)
    {
      services.AddScoped<IApiVersionDescriptionProvider, DefaultApiVersionDescriptionProvider>();
      services.AddApiVersioning(p => { p.ReportApiVersions = true; });
      services.AddVersionedApiExplorer(p =>
      {
        p.GroupNameFormat = "'v'VVV";
        p.SubstituteApiVersionInUrl = true;
      });

      return services;
    }
  }
}
