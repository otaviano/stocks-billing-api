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
  public class StockService : IStockService
  {
    private readonly IStockNoSqlRepository stockQueryRepository;
    private readonly IMediatorHandler bus;
    private readonly IMapper autoMapper;

    public StockService(
      IMapper autoMapper,
      IMediatorHandler bus,
      IStockNoSqlRepository stockQueryRepository)
    {
      this.bus = bus;
      this.autoMapper = autoMapper;
      this.stockQueryRepository = stockQueryRepository;
    }

    public async Task Create(StockViewModel model)
    {
      var command = autoMapper.Map<CreateStockCommand>(model);

      await bus.SendCommand(command);
    }

    public IEnumerable<StockViewModel> GetStocks()
    {
      var stocks = stockQueryRepository.GetAll();

      return autoMapper.Map<List<StockViewModel>>(stocks);
    }

    public StockViewModel Get(Guid id)
    {
      var stocks = stockQueryRepository.Get(id);

      return autoMapper.Map<StockViewModel>(stocks);
    }

    public IEnumerable<StockViewModel> Search(string name)
    {
      var stocks = stockQueryRepository.Search(name);

      return autoMapper.Map<List<StockViewModel>>(stocks);
    }
  }
}
