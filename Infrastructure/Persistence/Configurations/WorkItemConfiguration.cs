using Domain.Entities.WorkItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class WorkItemConfiguration : IEntityTypeConfiguration<WorkItem>
{
    public void Configure(EntityTypeBuilder<WorkItem> builder)
    {
        builder.Property(wi => wi.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(wi => wi.Description)
            .HasMaxLength(250);

        builder.Property(wi => wi.IsCompleted)
            .IsRequired();

        builder.Property(wi => wi.Position)
            .IsRequired();

        builder.HasOne(wi => wi.WorkColumn)
            .WithMany(wc => wc.WorkItems)
            .HasForeignKey(wi => wi.WorkColumnId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}