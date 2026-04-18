using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeManagement.Domain._Shared;

namespace RecipeManagement.Infrastructure.Persistence.Configurations;

internal class ParameterDefinitionConfiguration<TElement> : IEntityTypeConfiguration<TElement>
    where TElement : ParameterDefinition
{
    public virtual void Configure(EntityTypeBuilder<TElement> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();

        builder.Property(e => e.Name)
            .IsRequired(true);

        builder.Property(e => e.Value)
            .IsRequired(true);

        builder.Property(e => e.DataType)
            .IsRequired(false);

        builder.Property(e => e.Description)
            .IsRequired(false);
    }
}
