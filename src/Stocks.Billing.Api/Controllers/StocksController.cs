using Stocks.Billing.Application.Interfaces;
using Stocks.Billing.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;

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
      try
      {
        classService.Create(model);

        return Accepted();
      }
      // TODO : tratamento de exceptions
      //catch (ValidationException e)
      //{
      //    return BadRequest(new JsonErrorResponse(e.Errors));
      //}
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }

    [HttpGet]
    public ActionResult Get([FromQuery] string name)
    {
      try
      {
        var classes = classService.SearchStocks(Guid.Empty, name);

        return Ok(classes);
      }
      catch
      {
        return StatusCode((int)HttpStatusCode.InternalServerError);
      }
    }
  }
}
