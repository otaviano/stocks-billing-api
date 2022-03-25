using System.Collections.Generic;

namespace Stocks.Billing.Domain.Queries
{
  public class PagedResult<TEntity> where TEntity : class
  {
    public IEnumerable<TEntity> Items { get; set; }

    public PagedResultDetails Paging { get; set; }
    public PagedResult() =>
      Paging = new PagedResultDetails();
  }
}
