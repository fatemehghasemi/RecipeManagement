using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(150);

        builder.Property(x => x.DietaryPreference)
            .HasMaxLength(50);

        builder.Property(x => x.HealthGoal)
            .HasMaxLength(50);
    }
}
