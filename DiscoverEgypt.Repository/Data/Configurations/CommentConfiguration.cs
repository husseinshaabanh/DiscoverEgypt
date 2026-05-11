using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using DiscoverEgypt.Core.Entities;

namespace DiscoverEgypt.Repository.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(comment => comment.Content)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.HasOne(comment => comment.Tourist)
                   .WithMany(tourist => tourist.Comments)
                   .HasForeignKey(comment => comment.TouristId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(comment => comment.CommunityPost)
                   .WithMany(communityPost => communityPost.Comments)
                   .HasForeignKey(comment => comment.PostId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
