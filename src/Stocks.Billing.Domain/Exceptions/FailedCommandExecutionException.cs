using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.Serialization;

namespace Stocks.Billing.Domain.Exceptions
{
  [ExcludeFromCodeCoverage]
  [Serializable]
  public class FailedCommandExecutionException : BaseInvalidClientOperationException
  {
    public FailedCommandExecutionException(string msg) 
      : base(msg, HttpStatusCode.BadRequest) { }

    protected FailedCommandExecutionException(SerializationInfo info, StreamingContext context) : base(info, context, HttpStatusCode.BadRequest) { }
  }
}
