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
      MockClassList();

      var controller = new StocksController(_classesService.Object);
      var response = controller.Get(genericString);

      response.Should()
          .NotBeNull()
          .And.BeOfType<OkObjectResult>();
    }

    [Fact]
    public void GetClasses_GivenAValidRequest_ShouldReturnAListItems()
    {
      MockClassList();

      var controller = new StocksController(_classesService.Object);
      var okResult = controller.Get(genericString) as OkObjectResult;

      var items = Assert.IsAssignableFrom<IEnumerable<StockViewModel>>(okResult.Value);
      items.Should().HaveCount(10);
    }

    private void MockClassList()
    {
      var classes = _fixture
          .Build<StockViewModel>()
          .CreateMany(10);

      _classesService
          .Setup(p => p.SearchStocks(It.IsAny<Guid>(), It.IsAny<string>()))
          .Returns(classes);
    }
  }
}
