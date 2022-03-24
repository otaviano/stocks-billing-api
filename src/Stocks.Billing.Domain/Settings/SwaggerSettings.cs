namespace Stocks.Billing.Domain.Settings
{
  public class SwaggerSettings
  {
    public const string SectionName = "SwaggerSettings";

    public string Name { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
  }
}
