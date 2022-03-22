using System;

namespace Stocks.Billing.Domain.Entities
{
    public class HomeBroker : Entity
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }
}
