using Microsoft.Extensions.Logging;

namespace FastLogr.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class LogMessageAttribute : Attribute
{
    public string MessageTemplate { get; set; } = string.Empty;
    public LogLevel LogLevel { get; set; } = LogLevel.Information;
    public int EventId { get; set; } = 0;
    public string? EventName { get; set; } = default;
}