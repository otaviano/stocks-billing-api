using Stocks.Billing.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stocks.Billing.Application.Interfaces
{
  public interface IHomeBrokerService
  {
    IEnumerable<HomeBrokerViewModel> Search(Guid hash, string name);
    IEnumerable<HomeBrokerViewModel> Get();
    Task Create(HomeBrokerViewModel model);
  }
}
