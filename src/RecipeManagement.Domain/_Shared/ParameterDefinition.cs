namespace RecipeManagement.Domain._Shared;

public abstract class ParameterDefinition(string name, string value, string dataType, DateTime utcNow) : Entity(utcNow)
{
    public string Name { get; private set; } = name;
    public string Value { get; private set; } = value;
    public string DataType { get; private set; } = dataType;
}
