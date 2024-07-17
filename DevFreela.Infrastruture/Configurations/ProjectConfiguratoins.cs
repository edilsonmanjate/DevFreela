using DevFreela.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastruture.Configurations
{
    public class ProjectConfiguratoins : IEntityTypeConfiguration<Project>
    {
        public ProjectConfiguratoins() { }

        public void Configure(EntityTypeBuilder<Project> builder)
        {
           builder.HasKey(p => p.Id);
           
            builder
                .Property(e => e.StartedAt)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property(e => e.StartedAt)
                .HasDefaultValueSql("DATEADD(day, 14, CONVERT(date, GetDate()))");

            builder
                .HasOne(p => p.Freelancer)
                .WithMany(f => f.FreelanceProjects)
                .HasForeignKey(p => p.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

           builder
                .HasOne(p => p.Client)
                .WithMany(c => c.OwnedProjects)
                .HasForeignKey(p => p.IdClient)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(p => p.Comments)
                .WithOne()
                .HasForeignKey(pc => pc.IdProject)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
