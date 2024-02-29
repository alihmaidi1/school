namespace Dto.Admin.Admin;

public class GetAllAdmin
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public string? Image { get; set; }
    
    public string? Resize { get; set; } 
    
    public string? Hash { get; set; }
    public bool Status { get; set; }
}