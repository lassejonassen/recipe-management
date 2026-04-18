using RecipeManagement.Domain.ProcessSegments.Aggregates;

namespace RecipeManagement.Domain.ProcessSegments.Entities;

public sealed class ProcessSegmentParameter : ParameterDefinition
{
    private ProcessSegmentParameter(Guid processSegmentId, string name, string value, string dataType, bool isReadOnly, string defaultValue, DateTime utcNow)
        : base(name, value, dataType, utcNow)
    {
        ProcessSegmentId = processSegmentId;
        IsReadOnly = isReadOnly;
        DefaultValue = defaultValue;
    }
    public bool IsReadOnly { get; private set; }
    public string DefaultValue { get; private set; }
    public Guid ProcessSegmentId { get; private set; }
    public ProcessSegment ProcessSegment { get; } = null!;

    public static ProcessSegmentParameter Create(Guid processSegmentId, string name, string value, string dataType, bool isReadOnly, string defaultValue, DateTime utcNow)
    {
        var entity = new ProcessSegmentParameter(
            processSegmentId,
            name,
            value, 
            dataType,
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
