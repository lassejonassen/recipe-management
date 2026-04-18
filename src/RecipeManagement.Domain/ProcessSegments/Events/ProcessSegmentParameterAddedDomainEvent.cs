namespace RecipeManagement.Domain.ProcessSegments.Events;

public sealed record ProcessSegmentParameterAddedDomainEvent(
    Guid ProcessSegmentId,
    string ParameterName) : DomainEvent;
