using Common.Entity.Entity;
using EntityFrameworkCore.EncryptColumn.Attribute;

namespace Domain.Entities.Student.Parent;

public class Parent:BaseEntity<ParentID>
{

    public Parent()
    {

        Id = new ParentID(Guid.NewGuid());
        Students = new HashSet<Student.Student>();
    }
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    [EncryptColumn]
    public string Password { get; set; }
    
    public string? Image { get; set; }
    
    public string? Resize { get; set; }

    public string? Hash { get; set; }
    public ICollection<Student.Student> Students { get; set; }
}