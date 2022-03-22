using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stocks.Billing.Application.Interfaces;
using Stocks.Billing.Application.ViewModel;

namespace Stocks.Billing.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StocksController : ControllerBase
  {
    private readonly IStockService stockService;

    public StocksController(IStockService classService)
    {
      this.stockService = classService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] StockViewModel model)
    {
      await stockService.Create(model);

      return Accepted(model);
    }

    [HttpGet]
    public ActionResult Get([FromQuery] string name)
    {
      var stocks = stockService.Search(name);

      return Ok(stocks);
    }

    [HttpGet("{id}")]
    public ActionResult Get([FromRoute] Guid id)
    {
      var stock = stockService.Get(id);

      return Ok(stock);
    }
  }
}
