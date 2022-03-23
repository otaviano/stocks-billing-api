using Stocks.Billing.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stocks.Billing.Application.Interfaces
{
  public interface IHomeBrokerService
  {
    HomeBrokerViewModel Get(Guid hash);
    IEnumerable<HomeBrokerViewModel> Get();
    IEnumerable<HomeBrokerViewModel> Search(string name);
    Task<Guid> Create(CreateHomeBrokerViewModel model);
    Task Update(UpdateHomeBrokerViewModel model);
  }
}
