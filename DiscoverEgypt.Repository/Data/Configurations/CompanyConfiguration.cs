using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using DiscoverEgypt.Core.Entities;

namespace DiscoverEgypt.Repository.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(c => c.Email)
                   .HasMaxLength(100);

            builder.Property(c => c.Phone)
                   .HasMaxLength(20);

            builder.Property(c => c.Description)
                   .HasMaxLength(1000);
        }
    }
}
