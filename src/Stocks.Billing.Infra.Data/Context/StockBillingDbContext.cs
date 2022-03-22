using Stocks.Billing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Stocks.Billing.Infra.Data.Context
{
  public class StockBillingDbContext : DbContext
  {
    public DbSet<Stock> Stocks { get; set; }
    //public DbSet<Bill> Bills { get; set; }
    public DbSet<HomeBroker> HomeBrokers { get; set; }

    public StockBillingDbContext(DbContextOptions options)
        : base(options) { }
  }
}
