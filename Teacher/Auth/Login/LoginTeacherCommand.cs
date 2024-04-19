using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Teacher.Auth.Login;

public class LoginTeacherCommand: ICommand
{

    public string Email{get;set;}


    public string Password{get;set;}

}
