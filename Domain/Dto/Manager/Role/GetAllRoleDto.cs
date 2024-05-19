using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Manager.Role;

    public class GetAllRoleDto
    {

    
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<string> Permissions { get; set; }

    public DateTime CreatedAt { get; set; }

    }
