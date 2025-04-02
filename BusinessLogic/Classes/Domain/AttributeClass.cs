using BusinessLogic.Variables.Domain;

namespace BusinessLogic.Classes.Domain;

public class AttributeClass : Variable
{
    public Visibility Visibility { get; }

    public AttributeClass(string? name, TypeClass? type, Visibility visibility)
        : base(name, type)
    {
        Visibility = visibility;
    }
}