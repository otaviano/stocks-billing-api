using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Stocks.Billing.Application.Interfaces;
using Stocks.Billing.Application.ViewModel;
using Stocks.Billing.Domain.Commands;
using Stocks.Billing.Domain.Core.Bus;
using Stocks.Billing.Domain.Interfaces;

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

    public async Task Create(HomeBrokerViewModel model)
    {
      var command = autoMapper.Map<CreateHomeBrokerCommand>(model);

      await bus.SendCommand(command);
    }

    public IEnumerable<HomeBrokerViewModel> Get()
    {
      var homeBrokers = homeBrokerRepository.GetAll();

      return autoMapper.Map<List<HomeBrokerViewModel>>(homeBrokers);
    }

    public HomeBrokerViewModel Get(Guid hash)
    {
      var homeBrokers = homeBrokerRepository.Get(hash);

      return autoMapper.Map<HomeBrokerViewModel>(homeBrokers);
    }

    public IEnumerable<HomeBrokerViewModel> Search(string name)
    {
      var homeBrokers = homeBrokerRepository.Search(name);

      return autoMapper.Map<List<HomeBrokerViewModel>>(homeBrokers);
    }
  }
}
