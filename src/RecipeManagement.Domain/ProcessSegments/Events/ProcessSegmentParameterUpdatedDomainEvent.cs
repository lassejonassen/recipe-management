namespace RecipeManagement.Domain.ProcessSegments.Events;

public sealed record ProcessSegmentParameterUpdatedDomainEvent(
    Guid ProcessSegmentId,
    Guid ProcessSegmentParameterId,
    string ProcessSegmentParameterName) : DomainEvent;
