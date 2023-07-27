using Microsoft.Extensions.Logging;

namespace FastLogr.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class LogMessageAttribute : Attribute
{
    public string MessageTemplate { get; set; } = string.Empty;
    public LogLevel LogLevel { get; set; } = LogLevel.Information;
    public EventId EventId { get; set; } = new();
}