using Microsoft.Extensions.Logging.Abstractions;

namespace FastLogr.Generator.Tests.Integration.TestCode;

public class CustomTypesTests
{
    [Fact]
    public void Should_Write_LogMessageDefaultWithPrimitiveTypes()
    {
        // Arrange
        var sut = new CustomTypes();

        // Act
        var logger = NullLogger.Instance;
        logger.LogCustomType("just a string to test primitives with custom types", 
            new CustomRecord("custom fancy string", 420,true));
        
        // Assert
    }
}