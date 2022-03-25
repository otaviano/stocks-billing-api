using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stocks.Billing.Application.ViewModel;
using Stocks.Billing.Domain.Queries;

namespace Stocks.Billing.Application.Interfaces
{
  public interface IHomeBrokerService
  {
    GetHomeBrokerViewModelResponse Get(Guid hash);
    IEnumerable<GetHomeBrokerViewModelResponse> Get();
    PagedResult<GetHomeBrokerViewModelResponse> Search(GetHomeBrokerViewModelRequest query);
    Task<Guid> Create(CreateHomeBrokerViewModel model);
    Task Update(UpdateHomeBrokerViewModel model);
  }
}
