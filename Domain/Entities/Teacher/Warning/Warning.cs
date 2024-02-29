using Common.Entity.Entity;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Teacher;

namespace Domain.Entities.Teacher.Warning;

public class Warning:BaseEntity<WarningID>
{

    public Warning()
    {

        Id = new WarningID(Guid.NewGuid());
        
    }
    public string Reason { get; set; }
    public string Date { get; set; }

    
    public AdminID AdminId { get; set; }
    public Admin.Admin Admin { get; set; }
    
    
    
    public TeacherID TeacherId { get; set; }
    public Teacher.Teacher Teacher { get; set; }


}
