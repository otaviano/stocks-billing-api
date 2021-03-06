using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stocks.Billing.Application.Interfaces;
using Stocks.Billing.Application.ViewModel;

namespace Stocks.Billing.Api.Controllers
{
  [ApiController]
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/[controller]")]
  public class HomeBrokersController : ControllerBase
  {
    private readonly IHomeBrokerService homeBrokerService;

    public HomeBrokersController(IHomeBrokerService homeBrokerService)
    {
      this.homeBrokerService = homeBrokerService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateHomeBrokerViewModel model)
    {
      var id = await homeBrokerService.Create(model);

      return Accepted(new { Id = id });
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateHomeBrokerViewModel model)
    {
      await homeBrokerService.Update(model);

      return Accepted(model);
    }

    [HttpGet]
    public ActionResult Get([FromQuery] GetHomeBrokerViewModelRequest query)
    {
      var homeBrokers = homeBrokerService.Search(query);

      return Ok(homeBrokers);
    }

    [HttpGet("{id}")]
    public ActionResult Get([FromRoute] Guid id)
    {
      var homeBroker = homeBrokerService.Get(id);

      if (homeBroker != null)
        return Ok(homeBroker);

      return NotFound();
    }
  }
}
