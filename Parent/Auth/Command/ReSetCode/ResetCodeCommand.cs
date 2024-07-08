using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Parent.Auth.Command.ReSetCode;

public class ResetCodeCommand:ICommand
{


    public string Email{get;set;}

}
