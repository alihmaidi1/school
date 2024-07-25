using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.CQRS;

namespace Admin.Student.Parent.Command.Update;

public class UpdateParentCommand: ICommand
{

    public Guid Id{get;set;}

    public string Name{get;set;}

    public string Email{get;set;}


    public Guid? Image{get;set;}

}
