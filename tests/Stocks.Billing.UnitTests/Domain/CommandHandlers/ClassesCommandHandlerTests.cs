using AutoFixture;
using Stocks.Billing.Domain.CommandHandlers;
using Stocks.Billing.Domain.Commands;
using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Core.Exceptions;
using Stocks.Billing.Domain.Interfaces;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Stocks.Billing.UnitTests.Domain.CommandHandlers
{
  public class ClassesCommandHandlerTests
  {
    private readonly Mock<IStockRepository> classRepository;
    private readonly Mock<IStockNoSqlRepository> stockNoSqlRepository;
    private readonly StockCommandHandler classCommandHandler;
    private readonly Fixture fixture = new();
    private readonly CancellationToken cancelationToken;
    private const int genericNumber = 53;
    private const string genericString = "xpto";

    public ClassesCommandHandlerTests()
    {
      classRepository = new Mock<IStockRepository>();
      stockNoSqlRepository = new Mock<IStockNoSqlRepository>();
      cancelationToken = new CancellationToken();
      classCommandHandler = new StockCommandHandler(classRepository.Object, stockNoSqlRepository.Object);
    }

    [Fact]
    public async Task Handle_GivenAValidCreateClassCommand_ShouldCallCreateRepositoryAsync()
    {
      var command = new Mock<CreateStockCommand>(genericNumber, genericString, genericString);
      var stock = fixture
          .Build<Stock>()
          .Create();

      classRepository.Setup(p => p.Create(It.IsAny<Stock>()));
      await classCommandHandler.Handle(command.Object, cancelationToken);

      classRepository.Verify(x => x.Create(It.IsAny<Stock>()), Times.Once);
    }

    [Fact]
    public void Handle_GivenAnInvalidCreateClassCommand_ShouldThrow()
    {
      Assert.ThrowsAsync<InvalidCommandException>(() => classCommandHandler.Handle(null, new CancellationToken()));
    }
  }
}
