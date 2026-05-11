using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using DiscoverEgypt.Core.Entities;

namespace DiscoverEgypt.Repository.Data.Configurations
{
    public class CustomPlanConfiguration : IEntityTypeConfiguration<CustomPlan>
    {
        public void Configure(EntityTypeBuilder<CustomPlan> builder)
        {
            builder.ToTable("CustomPlans");

            builder.HasOne(customPlan => customPlan.Tourist)
                   .WithMany(tourist => tourist.CustomPlans)
                   .HasForeignKey(customPlan => customPlan.TouristId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
