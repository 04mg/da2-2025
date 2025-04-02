using BusinessLogic.Classes.Domain;
using BusinessLogic.Variables.Domain;
using FluentAssertions;

namespace BusinessLogic.Test.Classes.Domain;

[TestClass]
public class CustomAttributeTests
{
    [TestMethod]
    public void Constructor_WithValidParameters_ShouldInitializeProperties()
    {
        var type = new CustomType("string");
        var attribute = new CustomAttribute("username", type, Visibility.Public);

        attribute.Name.Should().Be("username");
        attribute.Type.Should().Be(type);
        attribute.Visibility.Should().Be(Visibility.Public);
    }

    [TestMethod]
    public void Constructor_WithNullName_ShouldThrowArgumentException()
    {
        var type = new CustomType("int");
        var act = () => new CustomAttribute(null, type, Visibility.Private);

        act.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void Constructor_WithNullType_ShouldThrowArgumentException()
    {
        var act = () => new CustomAttribute("age", null, Visibility.Protected);

        act.Should().Throw<ArgumentException>();
    }
}