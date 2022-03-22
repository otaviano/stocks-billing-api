using System.Threading;
using System.Threading.Tasks;
using Stocks.Billing.Domain.Commands;
using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Exceptions;
using Stocks.Billing.Domain.Interfaces;
using MediatR;

namespace Stocks.Billing.Domain.CommandHandlers
{
  public class HomeBrokerCommandHandler : IRequestHandler<CreateHomeBrokerCommand, Unit>
  {
    private readonly IHomeBrokerRepository schoolRepository;

    public HomeBrokerCommandHandler(IHomeBrokerRepository schoolRepository)
    {
      this.schoolRepository = schoolRepository;
    }

    public async Task<Unit> Handle(CreateHomeBrokerCommand request, CancellationToken cancellationToken)
    {
      // TODO : Extract to base or validations
      if (request == null)
      {
        throw new InvalidCommandException();
      }

      var homeBroker = new HomeBroker
      {
        Hash = request.Hash,
        Name = request.Name,
        Url = request.Url
      };

      await schoolRepository.Create(homeBroker);

      return await Unit.Task;
    }
  }
}
