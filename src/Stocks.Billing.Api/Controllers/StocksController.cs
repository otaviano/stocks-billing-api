using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stocks.Billing.Application.Interfaces;
using Stocks.Billing.Application.ViewModel;

namespace Stocks.Billing.Api.Controllers
{
  [ApiVersion("1.0")]
  [ApiController]
  [Route("api/v{version:apiVersion}/[controller]")]
  public class StocksController : ControllerBase
  {
    private readonly IStockService stockService;

    public StocksController(IStockService stockService)
    {
      this.stockService = stockService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateStockViewModel model)
    {
      var id = await stockService.Create(model);

      return Accepted(new { Id = id });
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateStockViewModel model)
    {
      await stockService.Update(model);

      return Accepted(model);
    }

    [HttpGet]
    public ActionResult Get([FromQuery] string ticker)
    {
      var stock = stockService.GetBy(ticker);

      return Ok(stock);
    }

    [HttpGet("{id}")]
    public ActionResult Get([FromRoute] Guid id)
    {
      var stock = stockService.Get(id);

      if (stock != null)
        return Ok(stock);

      return NotFound();
    }
  }
}
