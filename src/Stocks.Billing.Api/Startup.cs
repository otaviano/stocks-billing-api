using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stocks.Billing.Infra.IoC.Configurations;

namespace Stocks.Billing.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddMediatR(typeof(Startup));
      services.AddAutoMapper();
      services.AddCors();
      services.AddSettings(Configuration);
      services.AddSqlConnection(Configuration);
      services.AddNoSqlConnection();
      services.AddRepositories();
      services.AddDomain();
      services.AddServices();
      services.AddMessageBrokerInMemmory();
      services.AddApiVersion();
      services.AddSwagger(Configuration);
      services.AddHealthChecks(Configuration);
    }

    public void Configure(
      IApplicationBuilder app,
      IWebHostEnvironment env,
      IApiVersionDescriptionProvider provider)
    {
      if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
      else app.UseHttpsRedirection();

      app.ConfigureSwagger(Configuration, provider);
      app.UseRouting();
      app.UseAuthorization();
      app.ConfigureCors(Configuration);
      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}
