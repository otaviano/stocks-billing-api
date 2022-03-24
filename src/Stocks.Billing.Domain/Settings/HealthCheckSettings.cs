namespace Stocks.Billing.Domain.Settings
{
  public class HealthCheckSettings
  {
    public const string SectionName = "HealthCheckSettings";

    public string Url { get; set; }
    public string UrlSelf { get; set; }
    public string HealtyText { get; set; }
  }
}
