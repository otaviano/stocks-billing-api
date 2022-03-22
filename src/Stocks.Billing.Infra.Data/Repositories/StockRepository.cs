using System.Threading.Tasks;
using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Interfaces;
using Stocks.Billing.Infra.Data.Context;

namespace Stocks.Billing.Infra.Data.Repositories
{
  public class StockRepository : IStockRepository
  {
    private readonly StockBillingDbContext dbContext;

    public StockRepository(StockBillingDbContext dbContext) =>
        this.dbContext = dbContext;

    public async Task Create(Stock tock)
    {
      dbContext.Stocks.Add(tock);
      await dbContext.SaveChangesAsync();
    }
  }
}
