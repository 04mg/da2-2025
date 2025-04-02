using BusinessLogic.Methods.Domain;
using BusinessLogic.Variables.Domain;

namespace BusinessLogic.Classes.Domain;

public class CustomClass : CustomType
{
    public Modifier Modifier { get; }
    public CustomClass? ParentClass { get; private set; }
    public List<CustomAttribute> Attributes { get; } = [];
    public List<CustomMethod> Methods { get; } = [];

    public CustomClass(string name, Modifier modifier)
        : base(name)
    {
        Modifier = modifier;
    }

    public void SetParentClass(CustomClass parent)
    {
        EnsureClassIsNotSealed(parent);
        ParentClass = parent;
    }

    private static void EnsureClassIsNotSealed(CustomClass parent)
    {
        if (parent.Modifier == Modifier.Sealed)
            throw new InvalidOperationException("Cannot inherit from a sealed class.");
    }

    public IEnumerable<CustomAttribute> AllAttributes
    {
        get
        {
            var attributes = new List<CustomAttribute>(Attributes);
            AddNonPrivateParentAttributes(attributes);
            return attributes;
        }
    }

    private void AddNonPrivateParentAttributes(List<CustomAttribute> attributes)
    {
        if (ParentClass != null)
        {
            attributes.AddRange(GetNonPrivateParentAttributes());
        }
    }

    private IEnumerable<CustomAttribute> GetNonPrivateParentAttributes()
    {
        if (ParentClass != null)
        {
            return ParentClass.AllAttributes.Where(a => a.Visibility != Visibility.Private);
        }

        return [];
    }

    private IEnumerable<CustomMethod> GetNonPrivateParentMethods()
    {
        if (ParentClass != null)
        {
            return ParentClass.AllMethods.Where(m => m.Visibility != Visibility.Private);
        }

        return [];
    }

    public IEnumerable<CustomMethod> AllMethods
    {
        get
        {
            var methods = new List<CustomMethod>(Methods);
            AddNonPrivateParentMethods(methods);
            return methods;
        }
    }

    private void AddNonPrivateParentMethods(List<CustomMethod> methods)
    {
        if (ParentClass != null)
        {
            methods.AddRange(
                GetNonPrivateParentMethods()
            );
        }
    }

    private void EnsureParentClassIsNotNull(List<CustomMethod> methods)
    {
        if (ParentClass != null)
            methods.AddRange(ParentClass.AllMethods);
    }

    public void AddMethod(CustomMethod method)
    {
        EnsureMethodIsNotNull(method);
        Methods.Add(method);
    }

    private static void EnsureMethodIsNotNull(CustomMethod method)
    {
        if (method == null)
            throw new ArgumentException("Method cannot be null.");
    }

    public void CallMethod(string methodName)
    {
        EnsureClassIsNotAbstract();
        var method = AllMethods.FirstOrDefault(m => m.Name == methodName);
        EnsureMethodIsNotNull(methodName, method);
        method!.Execute();
    }

    private static void EnsureMethodIsNotNull(string methodName, CustomMethod? method)
    {
        if (method == null)
            throw new KeyNotFoundException($"Method '{methodName}' not found.");
    }

    private void EnsureClassIsNotAbstract()
    {
        if (Modifier == Modifier.Abstract)
            throw new InvalidOperationException("Cannot call methods directly on an abstract class.");
    }
}