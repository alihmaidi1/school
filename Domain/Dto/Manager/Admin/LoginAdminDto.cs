using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Manager.Admin;

public class LoginAdminDto
{

    public string Token{get;set;}
    public string RefreshToken{get;set;}

    public bool IsAdmin{get;set;}

    public Guid Id{get;set;}
    public string ExpireAt{get;set;}
    public List<string>Permissions{get;set;}


}
