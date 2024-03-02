using Common.Entity.Entity;

namespace Domain.Entities.Class.Year;

public class Year:BaseEntity<YearID>
{

    public Year()
    {

        Id = new YearID(Guid.NewGuid());
        ClassYears = new HashSet<ClassYear.ClassYear>();

    }
    
    
    public int Name { get; set; }
    
    public ICollection<ClassYear.ClassYear> ClassYears { get; set; } 
    
}