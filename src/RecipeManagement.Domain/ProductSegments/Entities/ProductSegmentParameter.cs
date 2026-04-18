using RecipeManagement.Domain.ProcessSegments.Aggregates;
using RecipeManagement.Domain.ProcessSegments.Entities;
using RecipeManagement.Domain.ProductSegments.Aggregates;
using RecipeManagement.Domain.ProductSegments.Errors;

namespace RecipeManagement.Domain.ProductSegments.Entities;

public class ProductSegmentParameter : ParameterDefinition
{
    private ProductSegmentParameter(Guid productSegmentId, string name, string value, string dataType, string actualValue, Guid sourceId, DateTime utcNow)
        : base(name, value, dataType, utcNow)   
    {
        ProductSegmentId = productSegmentId;
        ActualValue = actualValue;
        ProcessSegmentParameterId = sourceId;
    }

    public string ActualValue { get; private set; }
    public Guid ProcessSegmentParameterId { get; private set; }
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
            finalValue,
            template.Id,
            utcNow);

        return Result.Success(parameter);
    }
}