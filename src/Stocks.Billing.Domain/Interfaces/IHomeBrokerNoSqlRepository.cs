using System;
using System.Collections.Generic;
using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Queries;

namespace Stocks.Billing.Domain.Interfaces
{
  public interface IHomeBrokerNoSqlRepository : IHomeBrokerRepository
  {
    IEnumerable<HomeBroker> GetAll();
    HomeBroker Get(Guid hash);
    PagedResult<HomeBroker> Search(string name, int pageNumber, int pageSize);
  }
}
