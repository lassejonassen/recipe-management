using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeManagement.Domain.ProductSegments.Aggregates;
using RecipeManagement.Domain.ProductSegments.Enums;

namespace RecipeManagement.Infrastructure.Persistence.Configurations;

internal sealed class ProductSegmentConfiguration : IEntityTypeConfiguration<ProductSegment>
{
    public void Configure(EntityTypeBuilder<ProductSegment> builder)
    {
        builder.ToTable("ProductSegments");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();

        builder.HasMany(e => e.Parameters)
           .WithOne()
           .HasForeignKey(e => e.ProductSegmentId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.MaterialDefinition)
            .WithMany(e => e.ProductSegments)
            .HasForeignKey(e => e.MaterialDefinitionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ProcessSegment)
            .WithMany(e => e.ProductSegments)
            .HasForeignKey(e => e.ProcessSegmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.State)
            .HasConversion<string>()
            .HasDefaultValue(ProductSegmentState.Draft)
            .IsRequired();
    }
}
