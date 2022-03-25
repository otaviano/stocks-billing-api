using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Stocks.Billing.Application.Interfaces;
using Stocks.Billing.Application.ViewModel;
using Stocks.Billing.Domain.Commands;
using Stocks.Billing.Domain.Core.Bus;
using Stocks.Billing.Domain.Interfaces;
using Stocks.Billing.Domain.Queries;

namespace Stocks.Billing.Domain.Service
{
  public class HomeBrokerService : IHomeBrokerService
  {
    private readonly IMapper autoMapper;
    private readonly IMediatorHandler bus;
    private readonly IHomeBrokerNoSqlRepository homeBrokerRepository;

    public HomeBrokerService(
      IMapper autoMapper, 
      IMediatorHandler bus,
      IHomeBrokerNoSqlRepository homeBrokerRepository)
    {
      this.bus = bus;
      this.autoMapper = autoMapper;
      this.homeBrokerRepository = homeBrokerRepository;
    }

    public async Task<Guid> Create(CreateHomeBrokerViewModel model)
    {
      var command = autoMapper.Map<CreateHomeBrokerCommand>(model);

      await bus.SendCommand(command);
      return command.Hash;
    }

    public IEnumerable<GetHomeBrokerViewModelResponse> Get()
    {
      var homeBrokers = homeBrokerRepository.GetAll();

      return autoMapper.Map<List<GetHomeBrokerViewModelResponse>>(homeBrokers);
    }

    public GetHomeBrokerViewModelResponse Get(Guid hash)
    {
      var homeBrokers = homeBrokerRepository.Get(hash);

      return autoMapper.Map<GetHomeBrokerViewModelResponse>(homeBrokers);
    }

    public PagedResult<GetHomeBrokerViewModelResponse> Search(GetHomeBrokerViewModelRequest query)
    {
      query.PageSize = (query.PageSize > 50) ? 50 : query.PageSize;

      var homeBrokers = homeBrokerRepository.Search(query.Name, query.PageNumber, query.PageSize);
      var response = new PagedResult<GetHomeBrokerViewModelResponse>
      {
        Items = autoMapper.Map<List<GetHomeBrokerViewModelResponse>>(homeBrokers.Items),
        Paging = homeBrokers.Paging
      };

      return response;
    }

    public Task Update(UpdateHomeBrokerViewModel model)
    {
      throw new NotImplementedException();
    }
  }
}
