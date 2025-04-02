using BusinessLogic.Classes.Domain;
using BusinessLogic.Methods.Domain;
using BusinessLogic.Variables.Domain;
using FluentAssertions;

namespace BusinessLogic.Test.Methods.Domain;

[TestClass]
public class MethodClassTests
{
    private readonly TypeClass _returnType = new TypeClass("void");
    private readonly TypeClass _paramType = new TypeClass("int");

    [TestMethod]
    public void Constructor_WithValidParameters_ShouldInitializeEmptyLists()
    {
        var method = new MethodClass("Execute", _returnType, Visibility.Public);

        method.Name.Should().Be("Execute");
        method.ReturnType.Should().Be(_returnType);
        method.Visibility.Should().Be(Visibility.Public);
        method.Parameters.Should().BeEmpty();
        method.LocalVariables.Should().BeEmpty();
        method.InnerMethods.Should().BeEmpty();
    }

    [TestMethod]
    public void AddParameter_WithValidVariable_ShouldAddToParameters()
    {
        var method = new MethodClass("Calculate", _returnType, Visibility.Public);
        var parameter = new Variable("x", _paramType);

        method.AddParameter(parameter);

        method.Parameters.Should().ContainSingle().Which.Should().Be(parameter);
    }

    [TestMethod]
    public void AddLocalVariable_WithValidVariable_ShouldAddToLocalVariables()
    {
        var method = new MethodClass("Process", _returnType, Visibility.Private);
        var localVar = new Variable("temp", _paramType);

        method.AddLocalVariable(localVar);

        method.LocalVariables.Should().ContainSingle().Which.Should().Be(localVar);
    }

    [TestMethod]
    public void AddInnerMethod_WithValidMethod_ShouldAddToInnerMethods()
    {
        var parentMethod = new MethodClass("Parent", _returnType, Visibility.Protected);
        var innerMethod = new MethodClass("Child", _returnType, Visibility.Private);

        parentMethod.AddInnerMethod(innerMethod);

        parentMethod.InnerMethods.Should().ContainSingle().Which.Should().Be(innerMethod);
    }

    [TestMethod]
    public void AddParameter_WithNull_ShouldThrowArgumentException()
    {
        var method = new MethodClass("Test", _returnType, Visibility.Public);
        var act = () => method.AddParameter(null);

        act.Should().Throw<ArgumentException>();
    }
}