using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Abstraction;
using Domain.Base.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace infrastructure.Repository.Base;

public class GenericRepository<T>:IGenericRepository<T> where T : BaseEntity
{


    public readonly ApplicationDbContext DbContext;
    public GenericRepository(ApplicationDbContext DbContext) {

        this.DbContext = DbContext;
    }
    
    public virtual async Task<T> AddAsync(T entity)
    {
        await DbContext.Set<T>().AddAsync(entity);
        await DbContext.SaveChangesAsync();
        return entity;
    }

    public IDbContextTransaction BeginTransaction()
    {

        return DbContext.Database.BeginTransaction();
    }


    public void Commit()
    {

        DbContext.Database.CommitTransaction();
    }

    public async Task DeleteAsync(T entity)
    {

        DbContext.Set<T>().Remove(entity);
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task<List<T>> GetAllasync()
    {

        return await DbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {

        return await DbContext.Set<T>().FindAsync(id);

    }

    public IQueryable<T> GetTableAsNoTracking()
    {           
        return DbContext.Set<T>().AsNoTracking().AsQueryable();
    }

    public IQueryable<T> GetTableAsTracking()
    {
        return DbContext.Set<T>().AsTracking().AsQueryable();
    }

    public void Rollback()
    {
        DbContext.Database.RollbackTransaction();
    }

    public virtual async  Task  UpdateAsync(T entity)
    {

        DbContext.Set<T>().Update(entity);
        await DbContext.SaveChangesAsync();


    }

    public async Task<bool> IsExists(Guid id)
    {
        return DbContext.Set<T>().Any(x=>x.Id==id);
    }


    public  bool IsExistsByProperty(string property,object value)
    {
        var parameter = Expression.Parameter(typeof(T), "e");
        var propertyExpression = Expression.Property(parameter, property);
        var equals = Expression.Equal(propertyExpression, Expression.Constant(value));
        var predicate = Expression.Lambda<Func<T, bool>>(equals, parameter);
        return DbContext.Set<T>().Any(predicate);

    }


    public bool IsUnique(Guid id,string property,object value){


        var parameter = Expression.Parameter(typeof(T), "e");
        var propertyExpression = Expression.Property(parameter, property);
        var equals = Expression.Equal(propertyExpression, Expression.Constant(value));

        var idExpression = Expression.Property(parameter, "Id");
        var notEqual=Expression.NotEqual(idExpression, Expression.Constant(id));

        var predicate = Expression.Lambda<Func<T, bool>>(equals, parameter);
        var wherepredicate = Expression.Lambda<Func<T, bool>>(notEqual, parameter);
        return !DbContext.Set<T>().Where(wherepredicate).Any(predicate);


    }


    public T? GetByProperty(string property, object value)
    {
        
        var parameter = Expression.Parameter(typeof(T), "e");
        var propertyExpression = Expression.Property(parameter, property);
        var equals = Expression.Equal(propertyExpression, Expression.Constant(value));
        var predicate = Expression.Lambda<Func<T, bool>>(equals, parameter);
        return DbContext.Set<T>().FirstOrDefault(predicate);

        
    }



}
