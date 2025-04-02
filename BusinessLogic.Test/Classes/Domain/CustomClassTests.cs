using BusinessLogic.Classes.Domain;
using BusinessLogic.Methods.Domain;
using BusinessLogic.Variables.Domain;
using FluentAssertions;

namespace BusinessLogic.Test.Classes.Domain;

[TestClass]
public class CustomClassTests
{
    private readonly CustomType _baseType = new("Base");
    private readonly CustomMethod _baseMethod = new("Run", new CustomType("void"), Visibility.Public);
    private CustomClass _parentClass = null!;
    private CustomClass _childClass = null!;

    [TestInitialize]
    public void Initialize()
    {
        _parentClass = new CustomClass("Parent", Modifier.Concrete);
        _childClass = new CustomClass("Child", Modifier.Concrete);
        _childClass.SetParentClass(_parentClass);
    }

    [TestMethod]
    public void Constructor_WithValidNameAndModifier_ShouldInitialize()
    {
        var customClass = new CustomClass("Animal", Modifier.Abstract);

        customClass.Name.Should().Be("Animal");
        customClass.Modifier.Should().Be(Modifier.Abstract);
        customClass.Attributes.Should().BeEmpty();
        customClass.Methods.Should().BeEmpty();
        customClass.ParentClass.Should().BeNull();
    }

    [TestMethod]
    public void SetParentClass_WithSealedParent_ShouldThrowInvalidOperationException()
    {
        var sealedParent = new CustomClass("SealedParent", Modifier.Sealed);
        var childClass = new CustomClass("Child", Modifier.Concrete);

        var act = () => childClass.SetParentClass(sealedParent);

        act.Should().Throw<InvalidOperationException>().WithMessage("Cannot inherit from a sealed class.");
    }

    [TestMethod]
    public void InheritMethods_WithParentClass_ShouldIncludeParentMethods()
    {
        var parent = new CustomClass("Parent", Modifier.Concrete);
        parent.AddMethod(_baseMethod);

        var child = new CustomClass("Child", Modifier.Concrete);
        child.SetParentClass(parent);

        child.AllMethods.Should().Contain(_baseMethod);
    }

    [TestMethod]
    public void CallMethod_OnAbstractClass_ShouldThrowInvalidOperationException()
    {
        var abstractClass = new CustomClass("Abstract", Modifier.Abstract);
        abstractClass.AddMethod(_baseMethod);

        var act = () => abstractClass.CallMethod("Run");

        act.Should().Throw<InvalidOperationException>()
            .WithMessage("Cannot call methods directly on an abstract class.");
    }

    [TestMethod]
    public void AllAttributes_ShouldIncludePublicAndProtectedFromParent()
    {
        var privateAttr = new CustomAttribute("privateId", new CustomType("int"), Visibility.Private);
        var protectedAttr = new CustomAttribute("protectedName", new CustomType("string"), Visibility.Protected);
        var publicAttr = new CustomAttribute("publicFlag", new CustomType("bool"), Visibility.Public);

        _parentClass.Attributes.AddRange([privateAttr, protectedAttr, publicAttr]);

        var childAttributes = _childClass.AllAttributes.ToList();

        childAttributes.Should().NotContain(privateAttr);
        childAttributes.Should().Contain(protectedAttr);
        childAttributes.Should().Contain(publicAttr);
    }

    [TestMethod]
    public void AllMethods_ShouldFilterByVisibility()
    {
        var privateMethod = new CustomMethod("PrivateRun", new CustomType("void"), Visibility.Private);
        var protectedMethod = new CustomMethod("ProtectedInit", new CustomType("void"), Visibility.Protected);

        _parentClass.Methods.AddRange([privateMethod, protectedMethod]);

        var childMethods = _childClass.AllMethods.ToList();

        childMethods.Should().NotContain(privateMethod);
        childMethods.Should().Contain(protectedMethod);
    }
}