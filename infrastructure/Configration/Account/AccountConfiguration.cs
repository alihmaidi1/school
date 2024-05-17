using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.Account;

public class AccountConfiguration: IEntityTypeConfiguration<Domain.Entities.Account.Account>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Account.Account> builder)
    {
     
        builder.HasMany(x => x.AccountSessions)
            .WithOne(x => x.Account)
            .HasForeignKey(x => x.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(x=>x.DateDeleted==null);


        builder.HasMany(x=>x.AccountNotifications)
        .WithOne(x=>x.Account)
        .HasForeignKey(x=>x.AccountId)
        .OnDelete(DeleteBehavior.Restrict);

    }
}