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
    private readonly IHomeBrokerService schoolService;

    public HomeBrokersController(IHomeBrokerService schoolService)
    {
      this.schoolService = schoolService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] HomeBrokerViewModel model)
    {
      await schoolService.Create(model);

      return Accepted();
    }

    [HttpGet]
    public ActionResult Get([FromQuery] string name)
    {
        var schools = schoolService.Search(Guid.Empty, name);

        return Ok(schools);
    }
  }
}
