using Domain.Entities.WorkColumns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class WorkColumnConfiguration : IEntityTypeConfiguration<WorkColumn>
{
    public void Configure(EntityTypeBuilder<WorkColumn> builder)
    {
        builder.Property(wc => wc.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(wc => wc.Position)
            .IsRequired();

        builder.HasOne(wc => wc.Project)
            .WithMany(p => p.WorkColumns)
            .HasForeignKey(wc => wc.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}