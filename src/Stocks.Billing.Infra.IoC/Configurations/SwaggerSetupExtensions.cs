using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Stocks.Billing.Domain.Settings;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Stocks.Billing.Infra.IoC.Configurations
{
  [ExcludeFromCodeCoverage]
  public static class SwaggerSetupExtensions
  {
    public static void ConfigureSwagger(this IApplicationBuilder app, IConfiguration configuration, IApiVersionDescriptionProvider provider)
    {
      var settings = configuration.GetSection(SwaggerSettings.SectionName).Get<SwaggerSettings>()
        ?? throw new ArgumentNullException(nameof(SwaggerSettings), "Missing SwaggerCheckSettings on the app settings");

      app.UseSwagger();
      app.UseSwaggerUI(p =>
      {
        p.SupportedSubmitMethods(new SubmitMethod[] { });

        foreach (var description in provider.ApiVersionDescriptions)
        {
          p.SwaggerEndpoint(string.Format(settings.Url, description.GroupName), $"{settings.Name} - {description.GroupName.ToUpperInvariant()}");
        }
      });
      app.ConfigureHealthCheckEndpoints(configuration);
    }

    public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
      var settings = configuration.GetSection(SwaggerSettings.SectionName).Get<SwaggerSettings>()
        ?? throw new ArgumentNullException(nameof(SwaggerSettings), "Missing SwaggerCheckSettings on the app settings");

      services.AddSwaggerGen(p =>
      {
        var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

        foreach (var description in provider.ApiVersionDescriptions)
        {
          p.SwaggerDoc(description.GroupName,
            new OpenApiInfo
            {
              Title = settings.Name,
              Version = description.GroupName,
              Description = settings.Description
            });
        }

        p.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
      });
    }
  }
}
