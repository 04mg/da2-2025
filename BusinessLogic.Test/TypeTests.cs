using FluentAssertions;
using BusinessLogic;
using BusinessLogic.Types.Domain;
using Type = BusinessLogic.Types.Domain.Type;

namespace BusinessLogic.Test;

[TestClass]
public class TypeTests
{
    [TestMethod]
    public void Constructor_WithValidName_ShouldInitialize()
    {
        // Arrange
        var validName = "String";

        // Act
        var type = new Type(validName);

        // Assert
        type.Name.Should().Be(validName);
    }
}