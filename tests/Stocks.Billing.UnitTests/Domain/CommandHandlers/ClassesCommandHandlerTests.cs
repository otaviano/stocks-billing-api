using AutoFixture;
using Stocks.Billing.Domain.CommandHandlers;
using Stocks.Billing.Domain.Commands;
using Stocks.Billing.Domain.Entities;
using Stocks.Billing.Domain.Exceptions;
using Stocks.Billing.Domain.Interfaces;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Stocks.Billing.UnitTests.Domain.CommandHandlers
{
  public class ClassesCommandHandlerTests
  {
    private readonly Mock<IStockRepository> _classRepository;
    private readonly Mock<IStockNoSqlRepository> _stockNoSqlRepository;
    private readonly StockCommandHandler _classCommandHandler;
    private readonly Fixture _fixture = new Fixture();
    private readonly CancellationToken _cancelationToken;
    private const int genericNumber = 53;
    private const string genericString = "xpto";

    public ClassesCommandHandlerTests()
    {
      _classRepository = new Mock<IStockRepository>();
      _stockNoSqlRepository = new Mock<IStockNoSqlRepository>();
      _cancelationToken = new CancellationToken();
      _classCommandHandler = new StockCommandHandler(_classRepository.Object, _stockNoSqlRepository.Object);
    }

    [Fact]
    public async Task Handle_GivenAValidCreateClassCommand_ShouldCallCreateRepositoryAsync()
    {
      var command = new Mock<CreateStockCommand>(genericNumber, genericString, genericString);
      var stock = _fixture
          .Build<Stock>()
          .Create();

      _classRepository.Setup(p => p.Create(It.IsAny<Stock>()));
      await _classCommandHandler.Handle(command.Object, _cancelationToken);

      _classRepository.Verify(x => x.Create(It.IsAny<Stock>()), Times.Once);
    }

    [Fact]
    public void Handle_GivenAnInvalidCreateClassCommand_ShouldThrow()
    {
      Assert.ThrowsAsync<InvalidCommandException>(() => _classCommandHandler.Handle(null, new CancellationToken()));
    }
  }
}
