using AutoMapper;
using Stocks.Billing.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Stocks.Billing.Infra.IoC.Configurations
{
  public static class AutoMapperConfigExtension
  {
    public static void RegisterAutoMapper(this IServiceCollection services)
    {
      services.AddAutoMapper(typeof(AutoMapperConfiguration));
      AutoMapperConfiguration.RegisterMappings();
    }
  }
}
