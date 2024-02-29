using Common.Entity.Entity;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Teacher;

namespace Domain.Entities.Teacher.Vacation;

public class Vacation:BaseEntity<VacationID>
{

    public Vacation()
    {

        Id = new VacationID(Guid.NewGuid());
    }
    
    
    public string Reason{ get; set; }
    
    public bool? Status { get; set; }

    public int Days { get; set; }

    public string Date { get; set; }
    
    public AdminID AdminId { get; set; }
    public Admin.Admin Admin { get; set; }
    
    public Teacher.Teacher Teacher { get; set; } 
    public TeacherID TeacherId { get; set; }

}