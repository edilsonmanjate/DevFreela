﻿using DevFreela.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastruture.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder
                .HasMany(u => u.Skills)
                .WithOne()
                .HasForeignKey(us => us.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
