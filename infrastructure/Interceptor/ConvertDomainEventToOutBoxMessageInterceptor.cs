using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace infrastructure.Interceptor;

public class ConvertDomainEventToOutBoxMessageInterceptor:SaveChangesInterceptor
{


    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {

        DbContext? dbContext=eventData.Context;
        if(dbContext is null) return base.SavedChangesAsync(eventData,result,cancellationToken);
        var outBoxMessages=dbContext
        .ChangeTracker
        .Entries<BaseEntityWithoutId>()
        .Select(x=>x.Entity)
        .SelectMany(entity=>{

            var DomainEvents=entity.GetDomainEvents();
            entity.ClearDomainEvents();
            return DomainEvents;
        })
        .Select(domainevent=>new OutBoxMessage{


            Content=JsonConvert.SerializeObject(domainevent,new JsonSerializerSettings{

                TypeNameHandling= TypeNameHandling.All
            })


        })
        .ToList();
        dbContext.Set<OutBoxMessage>().AddRange(outBoxMessages);
        dbContext.SaveChanges();

        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }


}   
