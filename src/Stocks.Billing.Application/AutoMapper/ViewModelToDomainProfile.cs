using AutoMapper;
using Stocks.Billing.Application.ViewModel;
using Stocks.Billing.Domain.Commands;

namespace Stocks.Billing.Application.AutoMapper
{
  public class ViewModelToDomainProfile : Profile
  {
    public ViewModelToDomainProfile()
    {
      CreateMap<StockViewModel, CreateStockCommand>()
          .ConstructUsing(p => new CreateStockCommand(p.Ticker, p.Title, (short)p.Type));

      CreateMap<HomeBrokerViewModel, CreateHomeBrokerCommand>()
          .ConstructUsing(p => new CreateHomeBrokerCommand(p.Hash, p.Name, p.Url));
    }
  }
}
