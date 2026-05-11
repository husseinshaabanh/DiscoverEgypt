using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using DiscoverEgypt.Core.Entities;

namespace DiscoverEgypt.Repository.Data.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(tag => tag.Name)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
