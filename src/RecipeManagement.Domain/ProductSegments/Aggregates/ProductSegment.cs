using RecipeManagement.Domain.MaterialDefinitions.Aggregates;
using RecipeManagement.Domain.ProcessSegments.Aggregates;
using RecipeManagement.Domain.ProductSegments.Entities;
using RecipeManagement.Domain.ProductSegments.Enums;

namespace RecipeManagement.Domain.ProductSegments.Aggregates;

public sealed class ProductSegment : AggregateRoot
{
    private ProductSegment() { }
    private ProductSegment(DateTime utcNow) : base(utcNow) { }

    public Guid MaterialDefinitionId { get; private set; }
    public MaterialDefinition MaterialDefinition { get; } = null!;
    public Guid ProcessSegmentId { get; private set; }
    public ProcessSegment ProcessSegment { get; } = null!;
    public ProductSegmentState State { get; private set; }
    private readonly List<ProductSegmentParameter> _parameters = [];
    public IReadOnlyCollection<ProductSegmentParameter> Parameters => _parameters.AsReadOnly();
}
