using Stocks.Billing.Domain.Core.Commands;
using System.Threading.Tasks;

namespace Stocks.Billing.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
    }
}
