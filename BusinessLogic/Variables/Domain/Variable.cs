namespace BusinessLogic.Variables.Domain;

public class Variable
{
    public string? Name { get; }
    public CustomType? Type { get; }

    public Variable(string? name, CustomType? type)
    {
        EnsureNameIsNotNullOrWhitespace(name);
        EnsureTypeIsNotNull(type);

        Name = name;
        Type = type;
    }

    private static void EnsureTypeIsNotNull(CustomType? type)
    {
        if (type == null)
            throw new ArgumentException("Variable type cannot be null.");
    }

    private static void EnsureNameIsNotNullOrWhitespace(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Variable name cannot be null or whitespace.");
    }
}