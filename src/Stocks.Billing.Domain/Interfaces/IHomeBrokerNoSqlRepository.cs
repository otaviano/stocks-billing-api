using System;
using System.Collections.Generic;
using Stocks.Billing.Domain.Entities;

namespace Stocks.Billing.Domain.Interfaces
{
  public interface IHomeBrokerNoSqlRepository : IHomeBrokerRepository
  {
    IEnumerable<HomeBroker> Search(Guid hash, string name);
    IEnumerable<HomeBroker> GetAll();
  }
}
