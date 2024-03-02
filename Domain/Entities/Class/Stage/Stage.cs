using Common.Entity.Entity;

namespace Domain.Entities.Subject.Stage;

public class Stage:BaseEntity<StageID>
{

    public Stage()
    {
        Id = new StageID(Guid.NewGuid());
        Classes = new HashSet<Entities.Class.Class.Class>();

    }
    public string Name { get; set; }
    
    public ICollection<Entities.Class.Class.Class> Classes { get; set; }
    
}