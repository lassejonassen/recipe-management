using RecipeManagement.Domain.MaterialDefinitions.Errors;
using RecipeManagement.Domain.MaterialDefinitions.Repositories;

namespace RecipeManagement.Application.MaterialDefinitions.Queries;

public sealed record GetLatestMaterialDefinitionVersionQuery(Guid Id) : IRequest<Result<int>>;

public sealed class GetLatestMaterialDefinitionVersionQueryHandler(
    IMaterialDefinitionRepository repository)
    : IRequestHandler<GetLatestMaterialDefinitionVersionQuery, Result<int>>
{
    public async Task<Result<int>> Handle(GetLatestMaterialDefinitionVersionQuery request, CancellationToken cancellationToken)
    {
        var materialDefinition = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (materialDefinition is null)
            return Result.Failure<int>(MaterialDefinitionErrors.NotFound);

        int latestVersion = await repository.GetLatestVersionAsync(materialDefinition.Sku, cancellationToken);

        return Result.Success(latestVersion);
    }
}