using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Student.Auth.Command.Login;

public class LoginStudentCommand: ICommand
{

    public string Email{get;set;}


    public string Password{get;set;}

}
