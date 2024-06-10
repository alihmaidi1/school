using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Student.Auth.Command.RefreshToken;

public class RefreshStudentTokenCommand: ICommand
{

    public string RefreshToken{get;set;}

}
