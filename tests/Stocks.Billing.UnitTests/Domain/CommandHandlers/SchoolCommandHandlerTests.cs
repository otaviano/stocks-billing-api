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
    private readonly Mock<IHomeBrokerRepository> homeBrokerRepository;
    private readonly Mock<IHomeBrokerNoSqlRepository> homeBrokerNoSqlRepository;
    private readonly HomeBrokerCommandHandler schoolCommandHandler;
    private readonly Fixture fixture = new();
    private readonly CancellationToken cancelationToken;
    private const string GenericString = "xpto";

    public SchoolCommandHandlerTests()
    {
      homeBrokerRepository = new Mock<IHomeBrokerRepository>();
      homeBrokerNoSqlRepository = new Mock<IHomeBrokerNoSqlRepository>();
      cancelationToken = new CancellationToken();
      schoolCommandHandler = new HomeBrokerCommandHandler(homeBrokerRepository.Object, homeBrokerNoSqlRepository.Object);
    }

    [Fact]
    public async Task Handle_GivenAValidCreateSchoolCommand_ShouldCallCreateRepositoryAsync()
    {
      var command = new Mock<CreateHomeBrokerCommand>(GenericString, GenericString);
      var school = fixture
          .Build<Stock>()
          .Create();

      homeBrokerRepository.Setup(p => p.Create(It.IsAny<HomeBroker>()));
      await schoolCommandHandler.Handle(command.Object, cancelationToken);

      homeBrokerRepository.Verify(x => x.Create(It.IsAny<HomeBroker>()), Times.Once);
    }

    [Fact]
    public void Handle_GivenAnInvalidCreateSchoolCommand_ShouldThrow()
    {
      Assert.ThrowsAsync<InvalidCommandException>(() => schoolCommandHandler.Handle(null, new CancellationToken()));
    }
  }
}
