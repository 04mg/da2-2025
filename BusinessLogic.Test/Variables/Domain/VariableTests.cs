using BusinessLogic.Variables.Domain;
using FluentAssertions;

namespace BusinessLogic.Test.Variables.Domain;

[TestClass]
public class VariableTests
{
    [TestMethod]
    public void Constructor_WithValidNameAndType_ShouldInitializeProperties()
    {
        var type = new TypeClass("int");
        var variable = new Variable("age", type);

        variable.Name.Should().Be("age");
        variable.Type.Should().Be(type);
    }

    [TestMethod]
    public void Constructor_WithNullName_ShouldThrowArgumentException()
    {
        var type = new TypeClass("string");
        var act = () => new Variable(null, type);

        act.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void Constructor_WithEmptyName_ShouldThrowArgumentException()
    {
        var type = new TypeClass("string");
        var act = () => new Variable("", type);

        act.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void Constructor_WithWhitespaceName_ShouldThrowArgumentException()
    {
        var type = new TypeClass("string");
        var act = () => new Variable("   ", type);

        act.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void Constructor_WithNullType_ShouldThrowArgumentException()
    {
        var act = () => new Variable("name", null);

        act.Should().Throw<ArgumentException>();
    }
}