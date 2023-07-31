using FastLogr.Attributes;

namespace FastLogr.Generator.Tests.Integration.TestCode;

public class PrimitiveTypes
{
    [LogMessage(MessageTemplate = "Logging primitive types '{firstParameter}', '{secondParameter}' and '{thirdParameter}' with default values for log-message.")]
    private static Action<string, int, bool> LogMessageDefaultWithPrimitiveTypes;
}