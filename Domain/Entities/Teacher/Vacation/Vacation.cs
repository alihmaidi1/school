
using Domain.Base.Entity;
using Domain.Base.interfaces;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Teacher;
using Shared.Entity.Entity;

namespace Domain.Entities.Teacher.Vacation;

public class Vacation:BaseEntity,ISoftDelete
{

    public Vacation()
    {

        Id = Guid.NewGuid();
    }
    
    
    public string Reason{ get; set; }
    
    public bool? Status { get; set; }

    public int Days { get; set; }

    public DateTime Date { get; set; }
    
    public Guid? AdminId { get; set; }
    public Manager.Admin.Admin? Admin { get; set; }
    
    public Teacher.Teacher Teacher { get; set; } 
    public Guid TeacherId { get; set; }

}