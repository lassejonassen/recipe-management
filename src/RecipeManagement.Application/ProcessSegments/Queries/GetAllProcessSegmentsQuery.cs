using RecipeManagement.Application.ProcessSegments.DTOs;
using RecipeManagement.Domain.ProcessSegments.Repositories;

namespace RecipeManagement.Application.ProcessSegments.Queries;

public sealed record GetAllProcessSegmentsQuery : IRequest<IReadOnlyCollection<ProcessSegmentDTO>>;

public sealed class GetAllProcessSegmentsQueryHandler(
    IProcessSegmentRepository repository)
    : IRequestHandler<GetAllProcessSegmentsQuery, IReadOnlyCollection<ProcessSegmentDTO>>
{
    public async Task<IReadOnlyCollection<ProcessSegmentDTO>> Handle(GetAllProcessSegmentsQuery request, CancellationToken cancellationToken)
    {
        var entities = await repository.GetAllAsync(cancellationToken);

        return [.. entities.Select(e => new ProcessSegmentDTO {
            Id = e.Id,
            Name = e.Name,
            StableId = e.StableId,
            State = e.State.ToString(),
            Version = e.Version,
            CreatedAtUtc = e.CreatedAtUtc,
            UpdatedAtUtc = e.UpdatedAtUtc,
        })];
    }
}
