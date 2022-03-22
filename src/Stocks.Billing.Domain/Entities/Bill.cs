using System;

namespace Stocks.Billing.Domain.Entities
{
  public class Bill
  {
    public Guid Hash { get; set; }

    public Guid HomeBrokerHash { get; set; }

    public HomeBroker HomeBroker { get; set; }

    public Guid StockHash { get; set; }

    public Stock Stock { get; set; }

    public decimal Value { get; set; }

    public decimal NetValue { get; set; }

    public decimal Tax { get; set; }

    public decimal IRRFValue { get; set; }

    public OperationType OperationType { get; set; }

    public DateTime Date { get; set; }

    public DateTime NetDate { get; set; }
  }
}
