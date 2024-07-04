using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Parent.Auth.Command.ChangePassword;

public class ChangePasswordCommand: ICommand
{

    public string Password{get;set;}

}