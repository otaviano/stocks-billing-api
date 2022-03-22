using Stocks.Billing.Application.Interfaces;
using Stocks.Billing.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System;

namespace Stocks.Billing.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HomeBrokersController : ControllerBase
  {
    private readonly IHomeBrokerService homeBrokerService;

    public HomeBrokersController(IHomeBrokerService homeBrokerService)
    {
      this.homeBrokerService = homeBrokerService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] HomeBrokerViewModel model)
    {
      await homeBrokerService.Create(model);

      return Accepted(model);
    }

    [HttpGet]
    public ActionResult Get([FromQuery] string name)
    {
        var homeBrokers = homeBrokerService.Search(name);

        return Ok(homeBrokers);
    }

    [HttpGet("{id}")]
    public ActionResult Get([FromRoute] Guid id)
    {
      var homeBroker = homeBrokerService.Get(id);

      return Ok(homeBroker);
    }
  }
}
