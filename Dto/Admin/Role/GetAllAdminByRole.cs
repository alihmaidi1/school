namespace Dto.Admin.Role;

public class GetAllAdminByRole
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public string? Image { get; set; }
    

    public string? Hash { get; set; }
    public bool Status { get; set; }
}