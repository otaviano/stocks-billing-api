using System;
using System.Collections.Generic;
using Stocks.Billing.Domain.Entities;

namespace Stocks.Billing.Domain.Interfaces
{
  public interface IHomeBrokerNoSqlRepository : IHomeBrokerRepository
  {
    IEnumerable<HomeBroker> GetAll();
    HomeBroker Get(Guid hash);
    IEnumerable<HomeBroker> Search(string name);
  }
}
