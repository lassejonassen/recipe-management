namespace RecipeManagement.Domain.ProcessSegments.Events;

public sealed record ProcessSegmentParameterRemovedDomainEvent(
    Guid ProcessSegmentId,
    string ParameterName) : DomainEvent;
