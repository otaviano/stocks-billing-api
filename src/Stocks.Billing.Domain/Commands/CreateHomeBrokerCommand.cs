using System;

namespace Stocks.Billing.Domain.Commands
{
  public class CreateHomeBrokerCommand : HomeBrokerCommand
  {
    public CreateHomeBrokerCommand(Guid hash, string name, string url)
    {
      Hash = hash;
      Name = name;
      Url = url;
    }
  }
}
