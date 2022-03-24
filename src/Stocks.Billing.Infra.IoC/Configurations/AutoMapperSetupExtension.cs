using Microsoft.Extensions.DependencyInjection;
using Stocks.Billing.Application.AutoMapper;

namespace Stocks.Billing.Infra.IoC.Configurations
{
  public static class AutoMapperSetupExtension
  {
    public static void AddAutoMapper(this IServiceCollection services)
    {
      services.AddAutoMapper(typeof(AutoMapperConfiguration));
      AutoMapperConfiguration.RegisterMappings();
    }
  }
}
