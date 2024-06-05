using System.Linq.Expressions;
using System.Reflection;
using AutoMapper.Internal;
using Domain.Base.Entity;
using Domain.Base.interfaces;
using Domain.Entities.Account;
using Domain.Entities.ClassRoom;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Quez;
using Domain.Entities.Role;
using Domain.Entities.Student.Parent;
using Domain.Entities.Student.Student;
using Domain.Entities.Student.StudentSubject;
using Domain.Entities.Teacher;
using Domain.Entities.Teacher.Teacher;
using Domain.Entities.Teacher.Vacation;
using Domain.Entities.Teacher.Warning;
using infrastructure.Convertor;
using infrastructure.Interceptor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Shared.Entity.Entity;
using Shared.Services.User;

namespace infrastructure;

public class ApplicationDbContext:DbContext
{
    private readonly ICurrentUserService _currentUserService;
    public ApplicationDbContext(DbContextOptions option,ICurrentUserService currentUserService) :base(option)
    {
        _currentUserService = currentUserService;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new SoftDeleteInterceptor(_currentUserService))
                      .AddInterceptors(new AuditInterceptor(_currentUserService))
                      .AddInterceptors(new ConvertDomainEventToOutBoxMessageInterceptor());
        base.OnConfiguring(optionsBuilder);
    }


    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {

        configurationBuilder.Properties<TimeOnly>().HaveConversion<TimeOnlyConverter>();
        configurationBuilder.Properties<DateOnly>().HaveConversion<DateOnlyConverter>();
        
        base.ConfigureConventions(configurationBuilder);
    }
    protected override void OnModelCreating(ModelBuilder builder)
     {
         builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
         
         var entities = builder
             .Model
             .GetEntityTypes()
             .Where(e => e.ClrType.GetInterface(typeof(ISoftDelete).Name) != null&&e.GetMappingStrategy()==null)
             .Select(x => x.ClrType);


         foreach (var entity in entities)
         {
            
             builder.Entity(entity).HasIndex(nameof(ISoftDelete.DateDeleted));
             Expression<Func<IBaseEntity, bool>> expression = b => !b.DateDeleted.HasValue;
             var newParam = Expression.Parameter(entity);
             var newBody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);
             builder.Entity(entity).HasQueryFilter(Expression.Lambda(newBody, newParam));
         }
         base.OnModelCreating(builder);
    
     }

     
     public DbSet<Admin> Admins { get; init; }

     public DbSet<Role> Roles { get; init; }
     
     public DbSet<AccountSession> AccountSessions { get; init; }
     public DbSet<Teacher> Teachers { get; init; }
     public DbSet<Warning> Warnings { get; init; }
     public DbSet<Vacation> Vacations { get; init; }

     public DbSet<VacationType> VacationTypes{get;set;}

     public DbSet<Program> Programs{get;init;}
     
     
     public DbSet<Parent> Parents { get; init; }
     public DbSet<Student> Students { get; init; }
     public DbSet<Image> Images { get; init; }

    public DbSet<ClassYear> ClassYears{get;init;}

     public DbSet<Stage> Stages{get;init;}

     public DbSet<Class> Classes{get;init;}


     public DbSet<Subject> Subjects{get;init;}


     public DbSet<Bill> Bills{get;init;}

    public DbSet<SubjectYear> SubjectYears{get;init;}

    public DbSet<Year> Years{get;init;}

    public DbSet<StudentSubject> StudentSubjects{get;init;}


    public DbSet<Leson> Lesons{get;init;}


    public DbSet<StudentQuez> StudentQuezs{get;init;}

    public DbSet<Quez> Quezs{get;init;}
    public DbSet<Question> Questions{get;init;}


    public DbSet<Answer> Answers{get;init;}


    public DbSet<Notification> Notifications{get;init;}


    public DbSet<AccountNotification> AccountNotifications{get;init;}

    public DbSet<Account> Accounts{get;set;}

    public DbSet<OutBoxMessage> OutBoxMessages{get;init;}

    public DbSet<StudentAnswer> StudentAnswers{get;init;}

    public DbSet<TeacherSubject> TeacherSubjects{get;init;}


  }