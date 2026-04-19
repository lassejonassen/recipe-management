using RecipeManagement.Domain.MaterialDefinitions.Errors;
using RecipeManagement.Domain.MaterialDefinitions.Repositories;

namespace RecipeManagement.Application.MaterialDefinitions.Commands;

public sealed record ReleaseMaterialDefinitionCommand(Guid Id) : IRequest<Result>;

public sealed class ReleaseMaterialDefinitionCommandHandler(
    IMaterialDefinitionRepository repository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<ReleaseMaterialDefinitionCommand, Result>
{
    public async Task<Result> Handle(ReleaseMaterialDefinitionCommand request, CancellationToken cancellationToken)
    {
        var materialDefinition = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (materialDefinition is null)
            return Result.Failure(MaterialDefinitionErrors.NotFound);

        materialDefinition.Release();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
