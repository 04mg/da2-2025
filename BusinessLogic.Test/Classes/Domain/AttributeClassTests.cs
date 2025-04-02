using BusinessLogic.Classes.Domain;
using BusinessLogic.Variables.Domain;
using FluentAssertions;

namespace BusinessLogic.Test.Classes.Domain;

[TestClass]
public class AttributeClassTests
{
    [TestMethod]
    public void Constructor_WithValidParameters_ShouldInitializeProperties()
    {
        var type = new TypeClass("string");
        var attribute = new AttributeClass("username", type, Visibility.Public);

        attribute.Name.Should().Be("username");
        attribute.Type.Should().Be(type);
        attribute.Visibility.Should().Be(Visibility.Public);
    }

    [TestMethod]
    public void Constructor_WithNullName_ShouldThrowArgumentException()
    {
        var type = new TypeClass("int");
        var act = () => new AttributeClass(null, type, Visibility.Private);

        act.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void Constructor_WithNullType_ShouldThrowArgumentException()
    {
        var act = () => new AttributeClass("age", null, Visibility.Protected);

        act.Should().Throw<ArgumentException>();
    }
}