namespace RecipeManagement.WebAPI.Contracts.ProcessSegments;

public sealed record ProcessSegmentListResponseDTO
{
    public required IEnumerable<ProcessSegmentResponseDTO> Data { get; init; } = [];
}
