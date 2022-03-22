﻿using System;
using System.Runtime.Serialization;

namespace Stocks.Billing.Domain.Core.Exceptions
{
  public class NotFoundException : Exception
  {
    protected NotFoundException(string message) 
      : base(message) { }

    protected NotFoundException(SerializationInfo info, StreamingContext context) 
      : base(info, context) { }
  }
}
