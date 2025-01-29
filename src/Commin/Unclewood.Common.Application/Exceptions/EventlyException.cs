﻿using System.Runtime.InteropServices.JavaScript;

namespace Unclewood.Common.Application.Exceptions;

public sealed class EventlyException : Exception
{
    public EventlyException(string requestName, JSType.Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }

    public string RequestName { get; }

    public JSType.Error? Error { get; }
}
