using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Parent.Auth.Command.ForgetPassword;

public class ForgetPasswordCommand: ICommand
{

    public string Email{get;set;}

}
