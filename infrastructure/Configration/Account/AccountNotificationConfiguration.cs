using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.Account;

public class AccountNotificationConfiguration : IEntityTypeConfiguration<AccountNotification>
{
    public void Configure(EntityTypeBuilder<AccountNotification> builder)
    {

        builder.HasKey(x=>x.Id);
    }
}
