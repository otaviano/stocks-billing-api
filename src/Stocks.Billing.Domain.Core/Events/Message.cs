using MediatR;

namespace Stocks.Billing.Domain.Core.Events
{
  public abstract class Message : IRequest<Unit>
  {
    public string MessageType { get; protected set; }

    protected Message()
    {
      MessageType = GetType().Name;
    }
  }
}
