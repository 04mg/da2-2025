using BusinessLogic.Variables.Domain;

namespace BusinessLogic.Classes.Domain;

public class CustomAttribute : Variable
{
    public Visibility Visibility { get; }

    public CustomAttribute(string? name, CustomType? type, Visibility visibility)
        : base(name, type)
    {
        Visibility = visibility;
    }
}