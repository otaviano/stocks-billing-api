using System;
using Microsoft.AspNetCore.Mvc;
using Stocks.Billing.Application.Interfaces;
using Stocks.Billing.Application.ViewModel;

namespace Stocks.Billing.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StocksController : ControllerBase
  {
    private readonly IStockService classService;

    public StocksController(IStockService classService)
    {
      this.classService = classService;
    }

    [HttpPost]
    public IActionResult Post([FromBody] StockViewModel model)
    {
      classService.Create(model);

      return Accepted();
    }

    [HttpGet]
    public ActionResult Get([FromQuery] string name)
    {
      var classes = classService.SearchStocks(Guid.Empty, name);

      return Ok(classes);
    }
  }
}
