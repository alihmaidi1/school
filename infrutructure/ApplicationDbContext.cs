using System.Reflection;
using ClassDomain.Entities.Bill;
using ClassDomain.Entities.StudentClass;
using Domain.Entities.Admin;
using Domain.Entities.Class.Class;
using Domain.Entities.Class.ClassYear;
using Domain.Entities.Class.StudentBill;
using Domain.Entities.Class.Year;
using Domain.Entities.Role;
using Domain.Entities.Student.Parent;
using Domain.Entities.Student.Student;
using Domain.Entities.Subject.Stage;
using Domain.Entities.Teacher.Teacher;
using Domain.Entities.Teacher.Vacation;
using Domain.Entities.Teacher.Warning;
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
     public DbSet<Teacher> Teachers { get; set; }
     public DbSet<Warning> Warnings { get; set; }
     public DbSet<Vacation> Vacations { get; set; }
     
     
     public DbSet<Year> Years { get; set; }
     public DbSet<Stage> Stages { get; set; }
     public DbSet<Class> Classes { get; set; }
     public DbSet<AdminRefreshToken> AdminRefreshTokens { get; set; }
     
     public DbSet<Parent> Parents { get; set; }
     public DbSet<Student> Students { get; set; }
     public DbSet<ClassYear> ClassYears { get; set; }
     public DbSet<Bill> Bills { get; set; }
    
     public DbSet<StudentClass> StudentClasses { get; set; }
     public DbSet<StudentBill> StudentBills { get; set; }
}