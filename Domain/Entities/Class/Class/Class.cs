using Common.Entity.Entity;
using Domain.Entities.Subject.Class;
using Domain.Entities.Subject.Stage;

namespace Domain.Entities.Class.Class;

public class Class:BaseEntity<ClassID>
{

    public Class()
    {

        Id = new ClassID(Guid.NewGuid());
        ClassYears = new HashSet<ClassYear.ClassYear>();
    }
    
    public string Name { get; set; }
    
    public StageID StageId { get; set; }
    
    public Stage Stage { get; set; }
    
    
    public ICollection<ClassYear.ClassYear> ClassYears { get; set; }
    
}