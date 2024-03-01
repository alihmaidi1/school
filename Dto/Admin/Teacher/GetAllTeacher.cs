namespace Dto.Admin.Teacher;

public class GetAllTeacher
{
    
    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
    public string Name { get; set; }
    
    public string? Image { get; set; }

    public string? Hash { get; set; }

    public string? Resize { get; set; }

}