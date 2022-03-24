using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Stocks.Billing.Infra.IoC.Configurations
{
  public static class CorsSetupExtension
  {
    public static void ConfigureCors(this IApplicationBuilder app, IConfiguration configuration)
    {
      app.UseCors(builder =>
                builder.WithOrigins(configuration.GetValue<string>("CorsAllowedHosts"))
                    .AllowAnyHeader()
                    .AllowAnyMethod());
    }
  }
}
