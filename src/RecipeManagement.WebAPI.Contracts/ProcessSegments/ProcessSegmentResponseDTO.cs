namespace RecipeManagement.WebAPI.Contracts.ProcessSegments;

public sealed record ProcessSegmentResponseDTO
{
    public required Guid Id { get; init; }
    public required DateTime CreatedAtUtc { get; init; }
    public required DateTime UpdatedAtUtc { get; init; }
    public required string Name { get; init; }
    public required Guid StableId { get; init; }
    public required int Version { get; init; }
    public required string State { get; init; }
    public List<ProcessSegmentParameterResponseDTO>? Parameters { get; init; }
}
