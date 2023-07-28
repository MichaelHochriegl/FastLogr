﻿//HintName: LogExampleMessageExtensions.g.cs
using System;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Logging;
using FastLogr.Attributes;

namespace SourceGenPlayground.Example.Worker;
public static class LogExampleMessageExtensions
{
    private static readonly Action<ILogger, string, int, string?, Exception> s_logExampleMessage = LoggerMessage.Define<string, int, string?>(LogLevel.Information, new EventId(0, ""), "This is my example message with '{firstParameter}', '{secondParameter}' and an optional '{thirdParameter}'");
    public static void LogExampleMessage(this ILogger logger, string arg1, int arg2, string? arg3) => s_logExampleMessage(logger, arg1, arg2, arg3, default !);
}