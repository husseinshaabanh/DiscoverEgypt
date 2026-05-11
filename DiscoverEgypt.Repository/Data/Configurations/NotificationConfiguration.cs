using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using DiscoverEgypt.Core.Entities;

namespace DiscoverEgypt.Repository.Data.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(notification => notification.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(notification => notification.Content)
                   .HasMaxLength(1000);

            builder.HasOne(notification => notification.Tourist)
                   .WithMany(tourist => tourist.Notifications)
                   .HasForeignKey(notification => notification.TouristId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
