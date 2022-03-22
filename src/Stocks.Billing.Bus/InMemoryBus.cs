
using Stocks.Billing.Domain.Core.Bus;
using Stocks.Billing.Domain.Core.Commands;
using MediatR;
using System.Threading.Tasks;

namespace Stocks.Billing.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator mediator;

        public InMemoryBus(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return mediator.Send(command);
        }
    }
}
