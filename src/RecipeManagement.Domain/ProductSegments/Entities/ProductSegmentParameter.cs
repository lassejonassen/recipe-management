using RecipeManagement.Domain.ProcessSegments.Entities;
using RecipeManagement.Domain.ProductSegments.Aggregates;
using RecipeManagement.Domain.ProductSegments.Errors;

namespace RecipeManagement.Domain.ProductSegments.Entities;

public class ProductSegmentParameter : ParameterDefinition
{
    private ProductSegmentParameter()  { }
    private ProductSegmentParameter(Guid productSegmentId, string name, string value, string? dataType, string? description, string actualValue, Guid sourceId, DateTime utcNow)
        : base(name, value, dataType, description, utcNow)   
    {
        ProductSegmentId = productSegmentId;
        ActualValue = actualValue;
        ProcessSegmentParameterId = sourceId;
    }

    public string ActualValue { get; private set; } = string.Empty;
    public Guid ProcessSegmentParameterId { get; private set; }
    public ProcessSegmentParameter ProcessSegmentParameter { get; } = null!;
    public Guid ProductSegmentId { get; private set; }
    public ProductSegment ProductSegment { get; } = null!;

    public static Result<ProductSegmentParameter> CreateFromTemplate(Guid productSegmentId, ProcessSegmentParameter template, string actualValue, DateTime utcNow)
    {
        // Rule: If the template is read-only, the actual value MUST match the default
        if (template.IsReadOnly && actualValue != template.DefaultValue)
            return Result.Failure<ProductSegmentParameter>(ProductSegmentErrors.ParameterIsReadOnly);

        // Rule: If not read-only but value is null, we can fall back to the default
        var finalValue = string.IsNullOrWhiteSpace(actualValue) ? template.DefaultValue : actualValue;

        var parameter = new ProductSegmentParameter(
            productSegmentId,
            template.Name,
            template.Value,
            template.DataType,
            template.Description,
            finalValue,
            template.Id,
            utcNow);

        return Result.Success(parameter);
    }
}