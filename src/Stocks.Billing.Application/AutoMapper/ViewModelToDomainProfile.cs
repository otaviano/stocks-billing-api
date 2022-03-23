using System;
using AutoMapper;
using Stocks.Billing.Application.ViewModel;
using Stocks.Billing.Domain.Commands;

namespace Stocks.Billing.Application.AutoMapper
{
  public class ViewModelToDomainProfile : Profile
  {
    public ViewModelToDomainProfile()
    {
      CreateMap<CreateStockViewModel, CreateStockCommand>()
          .ConstructUsing(p => new CreateStockCommand(Guid.NewGuid(), p.Ticker, p.Title, (short)p.Type));

      CreateMap<UpdateStockViewModel, UpdateStockCommand>()
        .ConstructUsing(p => new UpdateStockCommand(p.Id, p.Ticker, p.Title, (short)p.Type));

      CreateMap<CreateHomeBrokerViewModel, CreateHomeBrokerCommand>()
          .ConstructUsing(p => new CreateHomeBrokerCommand(Guid.NewGuid(), p.Name, p.Url));

      CreateMap<UpdateHomeBrokerViewModel, UpdateHomeBrokerCommand>()
          .ConstructUsing(p => new UpdateHomeBrokerCommand(p.Id, p.Name, p.Url));
    }
  }
}
