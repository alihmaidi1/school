using Common.Entity.Entity;
using Domain.Base.interfaces;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Teacher;
using Shared.Entity.Entity;

namespace Domain.Entities.Teacher.Warning;

public class Warning:BaseEntity,ISoftDelete
{

    public Warning()
    {

        Id = Guid.NewGuid();
        
    }
    public string Reason { get; set; }
    public int Date { get; set; }

    
    public Guid AdminId { get; set; }
    public Manager.Admin.Admin Admin { get; set; }
    
    
    
    public Guid TeacherId { get; set; }
    public Teacher.Teacher Teacher { get; set; }


}
