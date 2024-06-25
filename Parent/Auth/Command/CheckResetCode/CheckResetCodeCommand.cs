using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Parent.Auth.Command.CheckResetCode;

public class CheckResetCodeCommand: ICommand
{

    public string Email{get;set;}

    public string Code{get;set;}

    public string FcmToken{get;set;}

}
