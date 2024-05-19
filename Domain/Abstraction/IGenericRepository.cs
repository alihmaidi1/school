using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Microsoft.EntityFrameworkCore.Storage;
using Shared.Entity.Interface;

namespace Domain.Abstraction;

public interface IGenericRepository <T> :IBaseSuper where T : BaseEntity
{

        
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<List<T>> GetAllasync();
    Task<bool> IsExists(Guid id);
    bool IsExistsByProperty(string property,object value);

    bool IsUnique(Guid id,string property,object value);

    
    T? GetByProperty(string property,object value);

    Task<T> GetByIdAsync(Guid id);
    void Commit();
    void Rollback();
    
    
    
    IDbContextTransaction BeginTransaction();


    

    IQueryable<T> GetTableAsNoTracking();
    IQueryable<T> GetTableAsTracking();


    


}
