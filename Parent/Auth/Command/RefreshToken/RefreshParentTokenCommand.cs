using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Parent.Auth.Command.RefreshToken;

public class RefreshParentTokenCommand: ICommand
{

    public string RefreshToken{get;set;}

}
