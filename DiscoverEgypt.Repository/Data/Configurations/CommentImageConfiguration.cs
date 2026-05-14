using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DiscoverEgypt.Core.Entities;

namespace DiscoverEgypt.Repository.Data.Configurations
{
    public class CommentImageConfiguration : IEntityTypeConfiguration<CommentImage>
    {
        public void Configure(EntityTypeBuilder<CommentImage> builder)
        {
            builder.Property(c => c.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.HasOne(c => c.Comment)
                   .WithMany(c => c.Images)
                   .HasForeignKey(c => c.CommentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}