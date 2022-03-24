using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Stocks.Billing.Domain.Commands;
using Stocks.Billing.Domain.Core.CommandHandlers;
using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Interfaces;

namespace Stocks.Billing.Domain.CommandHandlers
{
  public class HomeBrokerCommandHandler : CommandHandler, IRequestHandler<CreateHomeBrokerCommand, Unit>
  {
    private readonly IHomeBrokerRepository homeBrokerRepository;
    private readonly IHomeBrokerNoSqlRepository homeBrokerNoSqlRepository;

    public HomeBrokerCommandHandler(IHomeBrokerRepository homeBrokerRepository, IHomeBrokerNoSqlRepository homeBrokerNoSqlRepository)
    {
      this.homeBrokerRepository = homeBrokerRepository;
      this.homeBrokerNoSqlRepository = homeBrokerNoSqlRepository;
    }

    public async Task<Unit> Handle(CreateHomeBrokerCommand request, CancellationToken cancellationToken)
    {
      ValidateAndThrow(request);
      
      var homeBroker = new HomeBroker
      {
        Id = request.Hash,
        Name = request.Name,
        Url = request.Url,
        CreatedAt = DateTime.Now

      };

      await homeBrokerRepository.Create(homeBroker);
      await homeBrokerNoSqlRepository.Create(homeBroker);

      return await Unit.Task;
    }
  }
}
