using System.Reflection;
using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace infrutructure;

public class ApplicationDbContext:IdentityDbContext
{
    public IEncryptionProvider EncryptionProvider { get; set; }

    
    public ApplicationDbContext(DbContextOptions option) //:base(option)
    {

        EncryptionProvider = new GenerateEncryptionProvider("45sdfow342joir53");
            

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.UseEncryption(EncryptionProvider);

            
        base.OnModelCreating(builder);

    }


}