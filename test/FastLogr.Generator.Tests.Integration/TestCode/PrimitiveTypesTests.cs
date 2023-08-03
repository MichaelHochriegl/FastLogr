using Microsoft.Extensions.Logging.Abstractions;
using SourceGenPlayground.Example.Worker;

namespace FastLogr.Generator.Tests.Integration.TestCode;

public class PrimitiveTypesTests
{
    [Fact]
    public void Should_Write_LogMessageDefaultWithPrimitiveTypes()
    {
        // Arrange
        var sut = new PrimitiveTypes();

        // Act
        var logger = NullLogger.Instance;
        logger.LogMessageDefaultWithPrimitiveTypes("test String", 42, true);
        
        // Assert
    }
}