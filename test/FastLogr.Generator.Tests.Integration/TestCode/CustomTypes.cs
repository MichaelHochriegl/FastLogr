using FastLogr.Attributes;

namespace FastLogr.Generator.Tests.Integration.TestCode;

public class CustomTypes
{
    [LogMessage(MessageTemplate = "Logging {primitiveType} custom type: '{customType}'")]
    private static Action<string, CustomRecord> LogCustomType = default!;
}

public record CustomRecord(string CustomRecordString, int CustomRecordInt, bool CustomRecordBool);