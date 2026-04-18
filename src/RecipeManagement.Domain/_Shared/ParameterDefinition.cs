namespace RecipeManagement.Domain._Shared;

public class ParameterDefinition : Entity
{
    protected ParameterDefinition() { }
    protected ParameterDefinition(string name, string value, string? dataType, string? description, DateTime utcNow) : base(utcNow)
    {
        Name = name;
        Value = value;
        DataType = dataType;
        Description = description;
    }

    public string Name { get; protected set; } = string.Empty;
    public string Value { get; protected set; } = string.Empty;
    public string? DataType { get; protected set; }
    public string? Description { get; protected set; }
}
