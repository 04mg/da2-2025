using BusinessLogic.Classes.Domain;
using BusinessLogic.Variables.Domain;

namespace BusinessLogic.Methods.Domain;

public class CustomMethod
{
    public string Name { get; }
    public CustomType ReturnCustomType { get; }
    public Visibility Visibility { get; }
    public List<Variable> Parameters { get; } = [];
    public List<Variable> LocalVariables { get; } = [];
    public List<CustomMethod> InnerMethods { get; } = [];

    public CustomMethod(string name, CustomType returnCustomType, Visibility visibility)
    {
        EnsureMethodNameIsNotNullOrWhiteSpace(name);
        EnsureReturnTypeIsNotNull(returnCustomType);
        Name = name;
        ReturnCustomType = returnCustomType;
        Visibility = visibility;
    }

    private static void EnsureReturnTypeIsNotNull(CustomType returnCustomType)
    {
        if (returnCustomType == null)
            throw new ArgumentException("Return type cannot be null.");
    }
    
    private static void EnsureMethodNameIsNotNullOrWhiteSpace(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Method name cannot be null or whitespace.");
    }

    public void AddParameter(Variable parameter)
    {
        EnsureParameterIsNotNull(parameter);
        Parameters.Add(parameter);
    }

    private static void EnsureParameterIsNotNull(Variable parameter)
    {
        if (parameter == null)
            throw new ArgumentException("Parameter cannot be null.");
    }

    public void AddLocalVariable(Variable localVariable)
    {
        EnsureLocalVariableIsNotNull(localVariable);
        LocalVariables.Add(localVariable);
    }

    private static void EnsureLocalVariableIsNotNull(Variable localVariable)
    {
        if (localVariable == null)
            throw new ArgumentException("Local variable cannot be null.");
    }

    public void AddInnerMethod(CustomMethod innerCustomMethod)
    {
        EnsureInnerMethodIsNotNull(innerCustomMethod);
        InnerMethods.Add(innerCustomMethod);
    }

    private static void EnsureInnerMethodIsNotNull(CustomMethod innerCustomMethod)
    {
        if (innerCustomMethod == null)
            throw new ArgumentException("Inner method cannot be null.");
    }
}
