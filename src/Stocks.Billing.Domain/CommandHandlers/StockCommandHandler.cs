using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Stocks.Billing.Domain.Commands;
using Stocks.Billing.Domain.Core.CommandHandlers;
using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Interfaces;

namespace Stocks.Billing.Domain.CommandHandlers
{
  public class StockCommandHandler : CommandHandler, IRequestHandler<CreateStockCommand>
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
      ValidateAndThrow(request);

      var stock = new Stock
      {
        Id = request.Hash,
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
