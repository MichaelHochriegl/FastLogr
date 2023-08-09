//HintName: LogExampleMessageExtensions.g.cs
using System;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Logging;
using FastLogr.Attributes;

namespace MySourceGenTest;
public static class LogExampleMessageExtensions
{
    private static readonly Action<ILogger, string, int, string?, Exception> s_logExampleMessage = LoggerMessage.Define<string, int, string?>(LogLevel.Error, new EventId(1, "Foo"), "This is my example message with '{firstParameter}', '{secondParameter}' and an optional '{thirdParameter}'");
    public static void LogExampleMessage(this ILogger logger, string arg1, int arg2, string? arg3) => s_logExampleMessage(logger, arg1, arg2, arg3, default !);
}