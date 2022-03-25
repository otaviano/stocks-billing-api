using AutoMapper;
using Stocks.Billing.Application.ViewModel;
using Stocks.Billing.Domain.Entities;

namespace Stocks.Billing.Application.AutoMapper
{
  public class DomainToViewModelProfile : Profile
  {
    public DomainToViewModelProfile()
    {
      CreateMap<Stock, GetStockViewModelResponse>();
      CreateMap<HomeBroker, GetHomeBrokerViewModelResponse>();
    }
  }
}
