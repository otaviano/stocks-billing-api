using System;

namespace Stocks.Billing.Domain.Queries
{
  public class PagedResultDetails
  {
    public long TotalItems { get; set; }

    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public int PageCount { get; set; }

    public PagedResultDetails() { }

    public PagedResultDetails(int pageNumber, int pageSize, long totalItems)
    {
      CurrentPage = pageNumber;
      PageSize = pageSize;
      TotalItems = totalItems;
      PageCount = (int)Math.Ceiling((double)totalItems / pageSize);
    }
  }
}
