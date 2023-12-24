using System.Reflection;
using Domain.Entities.Admin;
using Domain.Entities.Role;
using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.EntityFrameworkCore;

namespace infrutructure;

public class ApplicationDbContext:DbContext
{
    public IEncryptionProvider EncryptionProvider { get; set; }

    
    public ApplicationDbContext(DbContextOptions option) :base(option)
    {

        EncryptionProvider = new GenerateEncryptionProvider("45sdfow342joir53");
            

    }
     protected override void OnModelCreating(ModelBuilder builder)
     {
         builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    
         builder.UseEncryption(EncryptionProvider);
         base.OnModelCreating(builder);
    
     }

    public DbSet<Admin> Admins { get; set; }

     public DbSet<Role> Roles { get; set; }
    
    
}