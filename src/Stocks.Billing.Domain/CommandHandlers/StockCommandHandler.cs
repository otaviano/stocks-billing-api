using System.Threading;
using System.Threading.Tasks;
using Stocks.Billing.Domain.Commands;
using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Exceptions;
using Stocks.Billing.Domain.Interfaces;
using MediatR;
using System;

namespace Stocks.Billing.Domain.CommandHandlers
{
  public class StockCommandHandler : IRequestHandler<CreateStockCommand>
  {
    private readonly IStockRepository stockRepository;
    private readonly IStockNoSqlRepository stockNoSqlRepository;

    public StockCommandHandler(IStockRepository stockRepository, IStockNoSqlRepository stockNoSqlRepository)
    {
      this.stockRepository = stockRepository;
      this.stockNoSqlRepository = stockNoSqlRepository;
    }

    public async Task<Unit> Handle(CreateStockCommand request, CancellationToken cancellationToken)
    {
      // TODO : Extract to base or validations
      if (request == null)
      {
        throw new InvalidCommandException();
      }

      var stock = new Stock
      {
        Hash = Guid.NewGuid(),
        Ticker = request.Ticker,
        Title = request.Title,
        Type = request.Type
      };

      await stockRepository.Create(stock);
      await stockNoSqlRepository.Create(stock);

      return await Unit.Task;
    }
  }
}
