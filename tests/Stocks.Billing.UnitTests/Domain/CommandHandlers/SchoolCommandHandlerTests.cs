using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using Stocks.Billing.Domain.CommandHandlers;
using Stocks.Billing.Domain.Commands;
using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Core.Exceptions;
using Stocks.Billing.Domain.Interfaces;
using Xunit;

namespace Stocks.Billing.UnitTests.Domain.CommandHandlers
{
  public class SchoolCommandHandlerTests
  {
    private readonly Mock<IHomeBrokerRepository> schoolRepository;
    private readonly HomeBrokerCommandHandler schoolCommandHandler;
    private readonly Fixture _fixture = new Fixture();
    private readonly CancellationToken cancelationToken;
    private const string GenericString = "xpto";

    public SchoolCommandHandlerTests()
    {
      schoolRepository = new Mock<IHomeBrokerRepository>();
      cancelationToken = new CancellationToken();
      schoolCommandHandler = new HomeBrokerCommandHandler(schoolRepository.Object);
    }

    [Fact]
    public async Task Handle_GivenAValidCreateSchoolCommand_ShouldCallCreateRepositoryAsync()
    {
      var command = new Mock<CreateHomeBrokerCommand>(GenericString, GenericString);
      var school = _fixture
          .Build<Stock>()
          .Create();

      schoolRepository.Setup(p => p.Create(It.IsAny<HomeBroker>()));
      await schoolCommandHandler.Handle(command.Object, cancelationToken);

      schoolRepository.Verify(x => x.Create(It.IsAny<HomeBroker>()), Times.Once);
    }

    [Fact]
    public void Handle_GivenAnInvalidCreateSchoolCommand_ShouldThrow()
    {
      Assert.ThrowsAsync<InvalidCommandException>(() => schoolCommandHandler.Handle(null, new CancellationToken()));
    }
  }
}
