using System.Diagnostics.CodeAnalysis;

namespace Stocks.Billing.Api.Filters
{
  [ExcludeFromCodeCoverage]
  public class JsonError
  {
    public int? Code { get; set; }

    public string Message { get; set; }

    public JsonError() { }

    public JsonError(string message, int? code = null)
    {
      Message = message;
      Code = code;
    }
  }
}
