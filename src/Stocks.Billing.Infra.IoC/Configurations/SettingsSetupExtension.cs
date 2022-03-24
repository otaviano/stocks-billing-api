﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Stocks.Billing.Domain.Settings;

namespace Stocks.Billing.Infra.IoC.Configurations
{
  public static class SettingsSetupExtension
  {
    public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
      services.Configure<HealthCheckSettings>(configuration.GetSection(HealthCheckSettings.SectionName));
      services.Configure<MongoDbSettings>(configuration.GetSection(MongoDbSettings.SectionName));
      services.Configure<SwaggerSettings>(configuration.GetSection(SwaggerSettings.SectionName));

      services.AddSingleton(p => p.GetRequiredService<IOptions<HealthCheckSettings>>().Value);
      services.AddSingleton(p => p.GetRequiredService<IOptions<MongoDbSettings>>().Value);
      services.AddSingleton(p => p.GetRequiredService<IOptions<SwaggerSettings>>().Value);
    }
  }
}
