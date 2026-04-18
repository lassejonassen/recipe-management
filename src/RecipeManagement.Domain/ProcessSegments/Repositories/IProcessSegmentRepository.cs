using RecipeManagement.Domain.ProcessSegments.Aggregates;

namespace RecipeManagement.Domain.ProcessSegments.Repositories;

public interface IProcessSegmentRepository : IRepository<ProcessSegment>
{
    Task<IReadOnlyCollection<ProcessSegment>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProcessSegment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> IsNameUniqueAsync(string sku, CancellationToken cancellationToken = default);
}
