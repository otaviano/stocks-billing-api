using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Interfaces;
using Stocks.Billing.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Stocks.Billing.Infra.Data.Repositories
{
  public class HomeBrokerRepository : IHomeBrokerRepository
  {
    private readonly StockBillingDbContext dbContext;

    public HomeBrokerRepository(StockBillingDbContext dbContext) =>
        this.dbContext = dbContext;

    public IQueryable<HomeBroker> GetAll() =>
        dbContext.HomeBrokers;

    public async Task Create(HomeBroker school)
    {
      dbContext.HomeBrokers.Add(school);
      await dbContext.SaveChangesAsync();
    }

    public IQueryable<HomeBroker> SearchSchools(string name) =>
        dbContext.HomeBrokers.Where(p => p.Name.Contains(name ?? string.Empty));
  }
}
