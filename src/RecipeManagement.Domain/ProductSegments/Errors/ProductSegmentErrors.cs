using RecipeManagement.Domain.ProductSegments.Aggregates;

namespace RecipeManagement.Domain.ProductSegments.Errors;

public static class ProductSegmentErrors
{
    private const string Prefix = nameof(ProductSegment);

    public static readonly Error ParameterIsReadOnly
        = new($"{Prefix}.ParameterIsReadOnly", "Parameter is read-only and cannot be changed.", ErrorType.Failure);
}
