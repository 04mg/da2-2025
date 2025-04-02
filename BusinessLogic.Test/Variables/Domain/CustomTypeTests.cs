using BusinessLogic.Variables.Domain;
using FluentAssertions;

namespace BusinessLogic.Test.Variables.Domain;

[TestClass]
public class CustomTypeTests
{
    [TestMethod]
    public void Constructor_WithValidName_ShouldInitialize()
    {
        // Arrange
        var validName = "String";

        // Act
        var type = new CustomType(validName);

        // Assert
        type.Name.Should().Be(validName);
    }
}