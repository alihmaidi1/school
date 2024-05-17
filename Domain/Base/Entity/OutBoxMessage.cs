using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Base.Entity;

public class OutBoxMessage
{

    public Guid Id{get;set;}=Guid.NewGuid();

    public string Type{get;set;}=string.Empty;


    public string Content{get;set;}=string.Empty;

    public DateTime CreateAt{get;set;}=DateTime.UtcNow;

    public DateTime? ProcessedAt{get;set;}

    public string? Error{get;set;}

}
