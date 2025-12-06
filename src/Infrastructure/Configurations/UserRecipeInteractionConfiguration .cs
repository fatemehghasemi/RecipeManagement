using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserRecipeInteractionConfiguration : IEntityTypeConfiguration<UserRecipeInteraction>
{
    public void Configure(EntityTypeBuilder<UserRecipeInteraction> builder)
    {
        builder.Property(x => x.Action)
            .HasMaxLength(30);
    }
}
