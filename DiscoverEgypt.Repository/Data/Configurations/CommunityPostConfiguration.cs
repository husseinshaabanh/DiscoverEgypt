using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using DiscoverEgypt.Core.Entities;

namespace DiscoverEgypt.Repository.Data.Configurations
{
    public class CommunityPostConfiguration : IEntityTypeConfiguration<CommunityPost>
    {
        public void Configure(EntityTypeBuilder<CommunityPost> builder)
        {
            builder.Property(communityPost => communityPost.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(communityPost => communityPost.Content)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.HasOne(communityPost => communityPost.Tourist)
                   .WithMany(tourist => tourist.CommunityPosts)
                   .HasForeignKey(communityPost => communityPost.TouristId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
