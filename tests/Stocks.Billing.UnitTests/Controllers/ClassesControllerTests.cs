using System;
using System.Collections.Generic;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Stocks.Billing.Api.Controllers;
using Stocks.Billing.Application.Interfaces;
using Stocks.Billing.Application.ViewModel;
using Xunit;

namespace Take.Zendesk.Integration.Tests.Controllers
{
  public class ClassesControllerTests
  {
    private readonly Mock<IStockService> _classesService;
    private readonly Fixture _fixture = new Fixture();
    private const int genericNumber = 53;
    private const string genericString = "xpto";

    public ClassesControllerTests()
    {
      _classesService = new Mock<IStockService>();
    }

    [Fact]
    public void GetClasses_GivenAValidRequest_ShouldReturnStatus200()
    {
      MockStockList();

      var controller = new StocksController(_classesService.Object);
      var response = controller.Get(genericString);

      response.Should()
          .NotBeNull()
          .And.BeOfType<OkObjectResult>();
    }

    [Fact]
    public void GetClasses_GivenAValidRequest_ShouldReturnAListItems()
    {
      MockStockList();

      var controller = new StocksController(_classesService.Object);
      var okResult = controller.Get(genericString) as OkObjectResult;

      var items = Assert.IsAssignableFrom<IEnumerable<CreateStockViewModel>>(okResult.Value);
      items.Should().HaveCount(10);
    }

    private void MockStockList()
    {
      var stocks = _fixture
          .Build<GetStockViewModelResponse>()
          .CreateMany(10);

      _classesService
          .Setup(p => p.GetBy(It.IsAny<string>()))
          .Returns(stocks);
    }
  }
}
