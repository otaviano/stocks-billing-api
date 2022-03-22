using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using Stocks.Billing.Domain.CommandHandlers;
using Stocks.Billing.Domain.Commands;
using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Exceptions;
using Stocks.Billing.Domain.Interfaces;
using Xunit;

namespace Stocks.Billing.UnitTests.Domain.CommandHandlers
{
  public class SchoolCommandHandlerTests
  {
    private readonly Mock<IHomeBrokerRepository> _schoolRepository;
    private readonly HomeBrokerCommandHandler _schoolCommandHandler;
    private readonly Fixture _fixture = new Fixture();
    private readonly CancellationToken _cancelationToken;
    private const string genericString = "xpto";

    public SchoolCommandHandlerTests()
    {
      _schoolRepository = new Mock<IHomeBrokerRepository>();
      _cancelationToken = new CancellationToken();
      _schoolCommandHandler = new HomeBrokerCommandHandler(_schoolRepository.Object);
    }

    [Fact]
    public async Task Handle_GivenAValidCreateSchoolCommand_ShouldCallCreateRepositoryAsync()
    {
      var command = new Mock<CreateHomeBrokerCommand>(genericString, genericString);
      var school = _fixture
          .Build<Stock>()
          .Create();

      _schoolRepository.Setup(p => p.Create(It.IsAny<HomeBroker>()));
      await _schoolCommandHandler.Handle(command.Object, _cancelationToken);

      _schoolRepository.Verify(x => x.Create(It.IsAny<HomeBroker>()), Times.Once);
    }

    [Fact]
    public void Handle_GivenAnInvalidCreateSchoolCommand_ShouldThrow()
    {
      Assert.ThrowsAsync<InvalidCommandException>(() => _schoolCommandHandler.Handle(null, new CancellationToken()));
    }
  }
}
