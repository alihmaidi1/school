using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit.Encodings;
using Shared.CQRS;

namespace Student.Auth.Command.ForgetPassword;

public class ForgetPasswordCommand: ICommand
{

    public string Email{get;set;}


}
