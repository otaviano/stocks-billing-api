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
  public class SchoolsControllerTests
  {
    private readonly Mock<IHomeBrokerService> _schoolService;
    private readonly Fixture _fixture = new Fixture();
    private const string genericString = "xpto";

    public SchoolsControllerTests()
    {
      _schoolService = new Mock<IHomeBrokerService>();
    }

    [Fact]
    public void GetSchools_GivenAValidRequest_ShouldReturnStatus200()
    {
      MockSchoolList();

      var controller = new HomeBrokersController(_schoolService.Object);
      var response = controller.Get(genericString);

      response.Should()
          .NotBeNull()
          .And.BeOfType<OkObjectResult>();

    }

    [Fact]
    public void GetSchools_GivenAValidRequest_ShouldReturnAListItems()
    {
      MockSchoolList();

      var controller = new HomeBrokersController(_schoolService.Object);
      var okResult = controller.Get(genericString) as OkObjectResult;

      var items = Assert.IsAssignableFrom<IEnumerable<HomeBrokerViewModel>>(okResult.Value);
      items.Should().HaveCount(10);
    }

    private void MockSchoolList()
    {
      var schools = _fixture
          .Build<HomeBrokerViewModel>()
          .CreateMany(10);

      _schoolService
          .Setup(p => p.Search(It.IsAny<string>()))
          .Returns(schools);
    }
  }
}
