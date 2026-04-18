using RecipeManagement.Domain.ProcessSegments.Aggregates;
using RecipeManagement.Domain.ProductSegments.Entities;

namespace RecipeManagement.Domain.ProcessSegments.Entities;

public sealed class ProcessSegmentParameter : ParameterDefinition
{
    private ProcessSegmentParameter() { }
    private ProcessSegmentParameter(Guid processSegmentId, string name, string value, string? dataType, string? description, bool isReadOnly, string defaultValue, DateTime utcNow)
        : base(name, value, dataType, description, utcNow)
    {
        ProcessSegmentId = processSegmentId;
        IsReadOnly = isReadOnly;
        DefaultValue = defaultValue;
    }
    public bool IsReadOnly { get; private set; }
    public string DefaultValue { get; private set; } = string.Empty;
    public Guid ProcessSegmentId { get; private set; }
    public ProcessSegment ProcessSegment { get; } = null!;
    private readonly List<ProductSegmentParameter> _productSegmentParameters = [];
    public IReadOnlyCollection<ProductSegmentParameter> ProductSegmentParameters => _productSegmentParameters.AsReadOnly();

    public static ProcessSegmentParameter Create(Guid processSegmentId, string name, string value, string? dataType, string? description, bool isReadOnly, string defaultValue, DateTime utcNow)
    {
        var entity = new ProcessSegmentParameter(
            processSegmentId,
            name,
            value, 
            dataType,
            description,
            isReadOnly,
            defaultValue, 
            utcNow);

        return entity;
    }

    public void UpdateRules(bool isReadOnly, string defaultValue)
    {
        isReadOnly = IsReadOnly;
        defaultValue = DefaultValue;
    }
}
