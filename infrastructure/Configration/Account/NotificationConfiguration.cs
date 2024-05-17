using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.Account;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {

        builder.HasKey(x=>x.Id);

        builder.HasMany(x=>x.AccountNotifications)
        .WithOne(x=>x.Notification)
        .HasForeignKey(x=>x.NotificationId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
