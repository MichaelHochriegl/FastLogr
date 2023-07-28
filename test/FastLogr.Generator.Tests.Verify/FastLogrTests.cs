namespace FastLogr.Generator.Tests.Verify;

[UsesVerify]
public class FastLogrTests
{
    [Fact]
    public Task GivenNonAttributedSource_Should_NotGenerate()
    {
        // Arrange
        const string source = """
         using System;

         namespace MySourceGenTest;

         public class Foo
         {
             private static Action<string, int, string?> LogExampleMessage;
         }
         """;

        // Act + Assert
        return TestHelper.Verify(source);
    }
    
    [Fact]
    public Task GivenAttributedSource_WithMinimalAttributeValues_WithBaseTypes_Should_Generate()
    {
        // Arrange
        const string source = """
         using System;
         using Microsoft.Extensions.Logging;
         using FastLogr.Attributes;

         namespace MySourceGenTest;

         public class Foo
         {
             [LogMessage(MessageTemplate = "This is my example message with '{firstParameter}', '{secondParameter}' and an optional '{thirdParameter}'")]
             private static Action<string, int, string?> LogExampleMessage;
         }
         """;

        // Act + Assert
        return TestHelper.Verify(source);
    }
    
    [Fact]
    public Task GivenAttributedSource_WithAllAttributeValues_WithBaseTypes_Should_Generate()
    {
        // Arrange
        const string source = """
         using System;
         using Microsoft.Extensions.Logging;
         using FastLogr.Attributes;

         namespace MySourceGenTest;

         public class Foo
         {
             [LogMessage(LogLevel = LogLevel.Error, EventId = 1, EventName = nameof(Foo), MessageTemplate = "This is my example message with '{firstParameter}', '{secondParameter}' and an optional '{thirdParameter}'")]
             private static Action<string, int, string?> LogExampleMessage;
         }
         """;

        // Act + Assert
        return TestHelper.Verify(source);
    }
}