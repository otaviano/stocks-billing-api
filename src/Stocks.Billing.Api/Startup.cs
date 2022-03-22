using Stocks.Billing.Infra.IoC;
using Stocks.Billing.Infra.IoC.Configurations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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
            services.AddSwaggerGen(p => p.SwaggerDoc("v1", new OpenApiInfo{ Title = "Eleva Case API", Version = "v1"}));
            services.AddMediatR(typeof(Startup));
            services.RegisterAutoMapper();
            services.AddCors();

            DependencyContainer.RegisterServices(Configuration, services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
            }

            app.UseSwagger();
            app.UseSwaggerUI(p => p.SwaggerEndpoint("/swagger/v1/swagger.json", "Eleva Case v1"));
            app.UseRouting();
            app.UseAuthorization();

            app.UseCors(builder =>
                builder.WithOrigins(Configuration.GetValue<string>("CorsAllowedHosts"))
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
