namespace Stocks.Billing.Domain.Settings
{
  public class SwaggerCheckSettings
  {
    public const string SectionName = "SwaggerCheckSettings";

    public string Name { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
  }
}
