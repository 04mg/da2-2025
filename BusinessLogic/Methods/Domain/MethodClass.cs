using BusinessLogic.Classes.Domain;
using BusinessLogic.Variables.Domain;

namespace BusinessLogic.Methods.Domain;

public class MethodClass
{
    public string Name { get; }
    public TypeClass ReturnType { get; }
    public Visibility Visibility { get; }
    public List<Variable> Parameters { get; } = [];
    public List<Variable> LocalVariables { get; } = [];
    public List<MethodClass> InnerMethods { get; } = [];

    public MethodClass(string name, TypeClass returnType, Visibility visibility)
    {
        EnsureMethodNameIsNotNullOrWhiteSpace(name);
        EnsureReturnTypeIsNotNull(returnType);
        Name = name;
        ReturnType = returnType;
        Visibility = visibility;
    }

    private static void EnsureReturnTypeIsNotNull(TypeClass returnType)
    {
        if (returnType == null)
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

    public void AddInnerMethod(MethodClass innerMethod)
    {
        EnsureInnerMethodIsNotNull(innerMethod);
        InnerMethods.Add(innerMethod);
    }

    private static void EnsureInnerMethodIsNotNull(MethodClass innerMethod)
    {
        if (innerMethod == null)
            throw new ArgumentException("Inner method cannot be null.");
    }
}
