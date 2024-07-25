using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Parent.Auth.Command.UpdateProfile;

public class UpdateProfileCommand: ICommand
{

    public string Name{get;set;}

    public string Email{get;set;}


    public string? Password{get;set;}

}
