using System;

namespace Stocks.Billing.Domain.Entities
{
    public class HomeBroker
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
    }
}
