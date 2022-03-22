using System.Threading.Tasks;
using Stocks.Billing.Domain.Entities;

namespace Stocks.Billing.Domain.Interfaces
{
  public interface IStockRepository
  {
    Task Create(Stock stock);
  }
}
