using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using DiscoverEgypt.Core.Entities;

namespace DiscoverEgypt.Repository.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(review => review.Rating)
                   .IsRequired();

            builder.HasOne(review => review.Tourist)
                   .WithMany(tourist => tourist.Reviews)
                   .HasForeignKey(review => review.TouristId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(review => review.Place)
                   .WithMany(place => place.Reviews)
                   .HasForeignKey(review => review.PlaceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(review => review.Guide)
                   .WithMany(guide => guide.Reviews)
                   .HasForeignKey(review => review.GuideId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(r => r.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
