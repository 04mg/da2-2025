using BusinessLogic.Variables.Domain;
using FluentAssertions;

namespace BusinessLogic.Test.Variables.Domain;

[TestClass]
public class TypeClassTests
{
    [TestMethod]
    public void Constructor_WithValidName_ShouldInitialize()
    {
        // Arrange
        var validName = "String";

        // Act
        var type = new TypeClass(validName);

        // Assert
        type.Name.Should().Be(validName);
    }
}