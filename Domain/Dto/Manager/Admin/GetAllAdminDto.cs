using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Manager.Admin;

public class GetAllAdminDto
{

    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime CreatedAt { get; set; }
    
    public string? Image { get; set; }
    
    public string? Hash { get; set; }
    public bool Status { get; set; }
    public string Role { get; set; }

}
