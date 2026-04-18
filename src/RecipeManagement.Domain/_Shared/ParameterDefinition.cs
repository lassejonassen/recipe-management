namespace RecipeManagement.Domain._Shared;

public abstract class ParameterDefinition : Entity
{
    protected ParameterDefinition() { }
    protected ParameterDefinition(string name, string value, string? dataType, string? description, DateTime utcNow) : base(utcNow)
    {
        Name = name;
        Value = value;
        DataType = dataType;
        Description = description;
    }

    public string Name { get; private set; } = string.Empty;
    public string Value { get; private set; } = string.Empty;
    public string? DataType { get; private set; }
    public string? Description { get; private set; }
}
