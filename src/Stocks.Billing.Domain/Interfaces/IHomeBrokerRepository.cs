using Stocks.Billing.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Billing.Domain.Interfaces
{
  public interface IHomeBrokerRepository
  {
    Task Create(HomeBroker school);
  }
}
