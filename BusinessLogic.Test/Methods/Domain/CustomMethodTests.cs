using BusinessLogic.Classes.Domain;
using BusinessLogic.Methods.Domain;
using BusinessLogic.Variables.Domain;
using FluentAssertions;

namespace BusinessLogic.Test.Methods.Domain;

[TestClass]
public class CustomMethodTests
{
    private readonly CustomType _returnCustomType = new CustomType("void");
    private readonly CustomType _paramCustomType = new CustomType("int");

    [TestMethod]
    public void Constructor_WithValidParameters_ShouldInitializeEmptyLists()
    {
        var method = new CustomMethod("Execute", _returnCustomType, Visibility.Public);

        method.Name.Should().Be("Execute");
        method.ReturnCustomType.Should().Be(_returnCustomType);
        method.Visibility.Should().Be(Visibility.Public);
        method.Parameters.Should().BeEmpty();
        method.LocalVariables.Should().BeEmpty();
        method.InnerMethods.Should().BeEmpty();
    }

    [TestMethod]
    public void AddParameter_WithValidVariable_ShouldAddToParameters()
    {
        var method = new CustomMethod("Calculate", _returnCustomType, Visibility.Public);
        var parameter = new Variable("x", _paramCustomType);

        method.AddParameter(parameter);

        method.Parameters.Should().ContainSingle().Which.Should().Be(parameter);
    }

    [TestMethod]
    public void AddLocalVariable_WithValidVariable_ShouldAddToLocalVariables()
    {
        var method = new CustomMethod("Process", _returnCustomType, Visibility.Private);
        var localVar = new Variable("temp", _paramCustomType);

        method.AddLocalVariable(localVar);

        method.LocalVariables.Should().ContainSingle().Which.Should().Be(localVar);
    }

    [TestMethod]
    public void AddInnerMethod_WithValidMethod_ShouldAddToInnerMethods()
    {
        var parentMethod = new CustomMethod("Parent", _returnCustomType, Visibility.Protected);
        var innerMethod = new CustomMethod("Child", _returnCustomType, Visibility.Private);

        parentMethod.AddInnerMethod(innerMethod);

        parentMethod.InnerMethods.Should().ContainSingle().Which.Should().Be(innerMethod);
    }

    [TestMethod]
    public void AddParameter_WithNull_ShouldThrowArgumentException()
    {
        var method = new CustomMethod("Test", _returnCustomType, Visibility.Public);
        var act = () => method.AddParameter(null);

        act.Should().Throw<ArgumentException>();
    }
}