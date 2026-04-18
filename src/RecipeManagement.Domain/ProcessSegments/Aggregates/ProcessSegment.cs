using RecipeManagement.Domain.ProcessSegments.Entities;
using RecipeManagement.Domain.ProcessSegments.Enums;
using RecipeManagement.Domain.ProductSegments.Aggregates;

namespace RecipeManagement.Domain.ProcessSegments.Aggregates;

public sealed class ProcessSegment : AggregateRoot
{
    private ProcessSegment() { }
    private ProcessSegment(DateTime utcNow) : base(utcNow) { }

    public string Name { get; private set; } = string.Empty;
    public Guid StableId { get; private set; }
    public int Version { get; private set; }
    public ProcessSegmentState State { get; private set; }

    private readonly List<ProcessSegmentParameter> _parameters = [];
    public IReadOnlyCollection<ProcessSegmentParameter> Parameters => _parameters.AsReadOnly();

    private readonly List<ProductSegment> _productSegments = [];
    public IReadOnlyCollection<ProductSegment> ProductSegments => _productSegments.AsReadOnly();
}
