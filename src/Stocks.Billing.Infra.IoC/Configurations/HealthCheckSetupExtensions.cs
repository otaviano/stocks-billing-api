using System;
using System.Diagnostics.CodeAnalysis;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Stocks.Billing.Domain.Settings;

namespace Stocks.Billing.Infra.IoC.Configurations
{
  [ExcludeFromCodeCoverage]
  public static class HealthCheckSetupExtensions
  {
    public static void ConfigureHealthCheckEndpoints(this IApplicationBuilder app, IConfiguration configuration)
    {
      var settings = configuration.GetSection(HealthCheckSettings.SectionName).Get<HealthCheckSettings>()
        ?? throw new ArgumentNullException(nameof(HealthCheckSettings), "Missing HealthCheckSettings on the app settings");

      app.UseHealthChecks(settings.Url, new HealthCheckOptions()
      {
        Predicate = (_) => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse

      });

      app.UseHealthChecks(settings.UrlSelf, new HealthCheckOptions()
      {
        Predicate = r => r.Name.Contains("self"),
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
      });
    }

    public static void AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
      var settings = configuration.GetSection(HealthCheckSettings.SectionName).Get<HealthCheckSettings>()
         ?? throw new ArgumentNullException(nameof(HealthCheckSettings), "Missing HealthCheckSettings on the app settings");
      var mongoDbSettings = configuration.GetSection(MongoDbSettings.SectionName).Get<MongoDbSettings>()
        ?? throw new ArgumentNullException(nameof(MongoDbSettings), "Missing MongoDbSettings on the app settings");


      services.AddHealthChecks()
        .AddCheck("self", () => HealthCheckResult.Healthy(settings.HealtyText))
        .AddSqlServer(
          connectionString: configuration.GetConnectionString("DbConnection"),
          name: "Sql Server"
        )
        .AddMongoDb(
          mongodbConnectionString: mongoDbSettings.ConnectionString,
          name: "MongoDb"
        );
    }
  }
}
