namespace Stocks.Billing.Domain.Commands
{
  public class CreateStockCommand : StockCommand
  {
    public CreateStockCommand(string ticker, string title, short type)
    {
      Ticker = ticker;
      Title = title;
      Type = (Entities.StockType) type;
    }
  }
}
